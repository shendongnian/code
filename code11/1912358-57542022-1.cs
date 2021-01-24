    public ActionResult MetodoRecibe(Reporte datas)
    {
      string name = "TableName"; // This has to be exact with EF entity name
      var type = ((IQueryable)efContext.GetType().GetProperty("TableName").GetValue(efContext)).ElementType;
      var dbSet = efContext.Set(type); 
      dbset.AddRange(dates.[name]);
      efContext.SaveChanges();
    }
