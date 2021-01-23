    using(DataTable tableschema = conn.GetSchema("TABLES"))
    {
        // first column name
        foreach(DataRow row in tableschema.Rows)
        {
            lstBoxLogs.Items.Add(row["TABLE_NAME"].ToString());
        }
    }
