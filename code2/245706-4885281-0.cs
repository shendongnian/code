        static void Main(string[] args)
        {
            DataTable dt = new DataTable("MyTable");
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            DataRow dr1 = dt.NewRow();
            dr1["Id"] = 1;
            dr1["Name"] = "John Smith";
            dt.Rows.Add(dr1);
            DataRow dr2 = dt.NewRow();
            dr2["Id"] = 2;
            dr2["Name"] = "John West";
            dt.Rows.Add(dr2);
    
            List<DataRow> list = dt.AsEnumerable().ToList();
            var strlist = from dr in list
                          select dr[0] + ", " + dr[1];
            var csv = string.Join(Environment.NewLine,strlist);
            Console.WriteLine(csv);
        }
