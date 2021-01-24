    // Use ToList() here so that we can modify the table while iterating over the rows
    foreach (DataRow row in dataTable.Rows.Cast<DataRow>().ToList())
    {
        int id = row.Field<int>("ID");
        string date = row.Field<string>("Date");
        string places = row.Field<string>("Places");
        foreach (string place in places.Split(','))
        {
            dataTable.Rows.Add(id, date, place);
        }
        row.Delete();  // delete the original row
    }
