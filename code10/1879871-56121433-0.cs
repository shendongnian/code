    try
    {
        string[] restrictions = new string[4] { null, null, "Students", null };
        DataTable schema = sqlConnection.GetSchema("Columns", restrictions); 
        foreach (DataRow row in schema.Rows)
        {
            listBox1.Items.Add(row.Field<string>("COLUMN_NAME"));
        }
    }
