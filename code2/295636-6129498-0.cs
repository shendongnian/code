    public class Test {
        public string Title { get; set; }
        public string Description { get; set; }
    }
    public class MyViewModel  {
        public MyViewModel() {
            var table = new DataTable("MyDatatable");
            table.Columns.Add("Some Val", typeof(double));
            table.Columns.Add("Ref", typeof(Test));
            var row = table.NewRow();
            row["Some Val"] = 3.14;
            row["Ref"] = new Test() { Title = "My Title", Description = "My Description" };
            table.Rows.Add(row);
            MyDataView = table.DefaultView;
        }
        public DataView MyDataView { get; set; }
    }
