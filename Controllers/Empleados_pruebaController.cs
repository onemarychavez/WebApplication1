using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Empleados_pruebaController : ApiController
    {
        private LDCOM_KIELSA_QA_SLVEntities1 db = new LDCOM_KIELSA_QA_SLVEntities1();

        // GET: api/Empleados_prueba
        public IQueryable<Empleados_prueba> GetEmpleados_prueba()
        {
            return db.Empleados_prueba;
        }

        // GET: api/Empleados_prueba/5
        [ResponseType(typeof(Empleados_prueba))]
        public IHttpActionResult GetEmpleados_prueba(int id)
        {
            Empleados_prueba empleados_prueba = db.Empleados_prueba.Find(id);
            if (empleados_prueba == null)
            {
                return NotFound();
            }

            return Ok(empleados_prueba);
        }

        // PUT: api/Empleados_prueba/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmpleados_prueba(int id, Empleados_prueba empleados_prueba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empleados_prueba.id)
            {
                return BadRequest();
            }

            db.Entry(empleados_prueba).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Empleados_pruebaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Empleados_prueba
        [ResponseType(typeof(Empleados_prueba))]
        public IHttpActionResult PostEmpleados_prueba(Empleados_prueba empleados_prueba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Empleados_prueba.Add(empleados_prueba);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = empleados_prueba.id }, empleados_prueba);
        }

        // DELETE: api/Empleados_prueba/5
        [ResponseType(typeof(Empleados_prueba))]
        public IHttpActionResult DeleteEmpleados_prueba(int id)
        {
            Empleados_prueba empleados_prueba = db.Empleados_prueba.Find(id);
            if (empleados_prueba == null)
            {
                return NotFound();
            }

            db.Empleados_prueba.Remove(empleados_prueba);
            db.SaveChanges();

            return Ok(empleados_prueba);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Empleados_pruebaExists(int id)
        {
            return db.Empleados_prueba.Count(e => e.id == id) > 0;
        }
    }
}