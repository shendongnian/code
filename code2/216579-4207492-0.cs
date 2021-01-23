    public SomeClass GetData()
    {
           var table = GetDataTable();
           var view = table.DefaultView;
           //..... more code
           var query = from row in view.ToTable().AsEnumerable()
                        group row by row.Field<string>("ShortName") into grouping
                        select new SomeClass
                            {
                                ShortName = grouping.Key,
                                SCount = grouping.Sum( count => count.Field<int>("ProfCount")),
                                DisplayText = string.Empty
                            };
            return query;
    }
    
    // this code doesn't work
    public void DoIt()
    {
      var result = GetData();
      string shortName = result.ShortName;
    }
    public class SomeClass
    {
        public string ShortName { get; set; }
        public int SCount { get; set; }
        public string DisplayText { get; set; }
    }
