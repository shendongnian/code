    public IEnumerable GetData() {
        var table = GetDataTable();
        var view = table.DefaultView;
        //..... more code
        var query = from row in view.ToTable().AsEnumerable()
                    group row by row.Field<string>("ShortName") into grouping
                    select new Foo
                        {
                            ShortName = grouping.Key,
                            SCount = grouping.Sum( count => count.Field<int>("ProfCount")),
                            DisplayText = string.Empty
                        };
        return query;
    }
    public void DoIt() {
        var result = GetData();
        PropertyInfo property = result.First().GetType().GetProperty("ShortName");
        foreach(var item in result) {
            string shortName = property.GetValue(item, null);
            Console.WriteLine(shortName);
        }
    }
