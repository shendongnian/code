    public object GetData()
    {
           var table = GetDataTable();
           var view = table.DefaultView;
           //..... more code
                var query = from row in view.ToTable().AsEnumerable()
                        group row by row.Field<string>("ShortName") into grouping
                        select new Object[]
                            {
                                grouping.Key,
                                grouping.Sum( count => count.Field<int>("ProfCount")),
                                string.Empty 
                            };
                return query;
    }
    
   
    public void DoIt()
    {
      // Note: Pretend that GetData returned only one result
      object[] result = GetData() as object[];
      var shortName = result[0];
    }
