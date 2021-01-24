    DataTable CreateDataTable()
    {
        var dt = new DataTable("tbl");
        dt.Columns.AddRange(new DataColumn[]
        {
            new DataColumn("Name", typeof(string)),
            new DataColumn("Age", typeof(int))
        });
        dt.Rows.Add("Jim", 23);
        dt.Rows.Add("Ard", 22);
        dt.Rows.Add("Tom", 30);
        return dt;
    }
