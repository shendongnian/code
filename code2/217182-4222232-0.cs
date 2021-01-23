    var table = new DataTable();
    var column = new DataColumn("Id", typeof (int));
    table.Columns.Add(column);
    table.PrimaryKey = new[] {column}; // Unique Constraint
    var row = table.NewRow();
    row["Id"] = 100;
    table.Rows.Add(row);
    row = table.NewRow();
    row["Id"] = 200;
    table.Rows.Add(row);
    var view = new DataView(table) { ApplyDefaultSort = true };
    var rows = view.FindRows(200);
    foreach(var r in rows)
    {
        Console.WriteLine(r["Id"]);
    }
