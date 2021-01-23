        static void Main(string[] args)
        {
            var minimunAge = 10;
            var t = new DataTable();
            t.Columns.Add("age", typeof(Int32));
            t.Columns.Add("gender", typeof(string));
            t.Columns.Add("name", typeof(string));
            t.Rows.Add(20, "M", "Steve");
            t.Rows.Add(5, "M", "John");
            t.Rows.Add(32, "F", "Mary");
            
            var view = t.AsEnumerable().Where(r => r.Field<Int32>("age") > minimunAge && r.Field<string>("gender") == "M").AsDataView();
        }
