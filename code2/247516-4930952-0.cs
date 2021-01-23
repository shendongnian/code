    foreach (DataRow row in dt.Rows)
    {
        foreach (DataColumn col in dt.Columns)
        {
            Console.Write(row[col].ToString());
        }
        Console.WriteLine("");
    }
