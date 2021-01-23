        var table = new DataTable();
        table.Columns.Add("id");
        table.Columns.Add("name");
        table.Columns.Add("unit");
        table.Rows.Add(1, "a Name", "a Unit");
        var rows = table.Select("Id=1");
        var exists = rows.Length > 0;
