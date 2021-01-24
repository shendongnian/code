    // Let's create a DataTable which holds the recors you want to get from the db
    DataTable dt = new DataTable();
    dt.Columns.Add("Category Name");
    dt.Columns.Add("Model");
    // Let's put in data
    dt.Rows.Add(new[] { "Honda", "Honda City" });
    dt.Rows.Add(new[] { null, "Honda Civic" });
    dt.Rows.Add(new[] { "Toyota", "Swift" });
    dt.Rows.Add(new[] { null, "Toyota GLI" });
    dt.Rows.Add(new[] { null, "Toyota XLI" });
    // dt is now what you want to get from your db.
    // Let's see what we got:
    Console.WriteLine(dt.Columns[0].ColumnName.PadRight(20) + dt.Columns[1].ColumnName.PadRight(20)); // PadRight to make it look better..
    foreach (DataRow item in dt.Rows)
    {
        Console.WriteLine((item[0] + "").PadRight(20) + (item[1] + "").PadRight(20));
    }
