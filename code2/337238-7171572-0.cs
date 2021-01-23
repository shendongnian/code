    static void Main(string[] args)
    {
        DataTable table = new DataTable();
      
        table.Columns.Add("col1");
        table.Columns.Add("col2");
        table.Rows.Add(new object[] { "1", "1" });
        table.Rows.Add(new object[] { "1", "1" });
        table.Rows.Add(new object[] { "1", "1" });
        table.Rows.Add(new object[] { "1", "1" });
        foreach (DataRow row in table.Rows)
            Console.WriteLine(row["col2"].ToString());
        Console.WriteLine("***************************************");
        DataColumn dc = new DataColumn("col2");
        dc.DataType = typeof(int);
        dc.DefaultValue = 0;
        table.Columns.Remove("col2");
        table.Columns.Add(dc);
        foreach (DataRow row in table.Rows)
            Console.WriteLine(row["col2"].ToString());
        Console.ReadKey();
    }
