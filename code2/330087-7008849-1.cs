       using (var db = new Context())
       {
          db.UFs.Attach(editedUF);
          editedUF.PaisId = theForeignKey;
          db.Entry(editedUF).State = EntityState.Modified;
          db.SaveChanges();
       }
