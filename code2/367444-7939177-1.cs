    DataTable dt = new DataTable("MyTable");
    foreach (DataRow row in dt.Rows)
    {
        foreach (DataColumn column in dt.Columns)
        {
            if (row[column] != null) // This will check the null values also (if you want to check).
            {
                   // Do whatever you want.
            }
         }
    }
