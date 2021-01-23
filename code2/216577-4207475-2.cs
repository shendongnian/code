    public class Foo {
        public string ShortName { get; set; }
        public int SCount { get; set; }
        public string DisplayText { get; set; }
    }
    public IEnumerable<Foo> GetData() {
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
        foreach(var item in result) {
            Console.WriteLine(item.ShortName);
        }
    }
