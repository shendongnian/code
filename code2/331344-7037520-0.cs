    public ActionResult BeAwesome(foo doo)
    {
      db.Entry(doo).State = EntityState.Modified;
      foo.Bars.ForEach(b => db.Entry(b).State = EntityState.Modified);
      db.SaveChanges();
      return View(doo);
    }
