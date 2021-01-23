    public IEnumerable<MyType> GetQuery()
    {
      var query = from row in stats.AsEnumerable()
                        group row by row.Field<string>("date") into grp
                        select new { Date = grp.Key, Count = grp.Count(t => t["date"] != null) }; 
      foreach (var rw  in query)
      {
         yield return new MyType(rw.Date, rw.Count);
      }
    }
