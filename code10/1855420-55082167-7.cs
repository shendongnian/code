    while (reader.Read())
    {
        // create an array big enough to hold all columns
        string[] qc = new string[reader.FieldCount];
        // iterate over all columns of your reader
        for (int i = 0; i < reader.FieldCount; i++)
        {
            // add to array
            qc[i] = reader.GetSqlString(i).IsNull ? null : reader.GetSqlString(i).Value;
        }
        label1.Text = string.Join("|", qc.Where(s => !string.IsNullOrEmpty(s));
    }
