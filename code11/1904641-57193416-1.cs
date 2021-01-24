    var dt = new DataTable();
    dt.Columns.Add("Column1");
    dt.Columns.Add("Column2");
    dt.Columns.Add("Column3");
    dt.Columns.Add("Column4");
    dt.Rows.Add("1", "2", "3", "4");
    var newDt = CutDataTable(dt, new[] { "Column3", "Column4" });
    Console.WriteLine("New column count = " + newDt.Columns.Count);
    Console.WriteLine("First row data: " + string.Join(",", newDt.Rows[0].ItemArray));
