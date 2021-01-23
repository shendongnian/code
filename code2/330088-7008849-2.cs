       using (var db = new Context())
       {
          ExistingPais pais = new Pais{Id =theId};
          db.Pais.Attach(pais);
          db.UF.Attach(editedUF);
          editedUF.Pais = pais;
          db.Entry(editedUF).State = EntityState.Modified;
          db.SaveChanges();
       }
