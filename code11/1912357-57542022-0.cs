    public ActionResult MetodoRecibe(Reporte datas)
    {
      string name = "TableName"; // This has to be exact with EF entity name
      var dbset = (System.Data.Entity.DbSet)efContext.GetType().GetProperty("TableName").GetValue(efContext);
      dbset.AddRange(dates.[name]);
      efContext.SaveChanges();
    }
