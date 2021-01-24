    public IHttpActionResult PutAktivnost([FromBody] AktivnostEditVM aktivnost)
    {
         db.Entry(aktivnost).State = System.Data.Entity.EntityState.Modified;
         db.SaveChanges();
         return Ok();
    }
