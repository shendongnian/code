    while (reader.Read())
    {
        // create an array big enough to hold all columns
        object[] qc = new object[reader.FieldCount];
        // iterate over all columns of your reader
        for (int i = 0; i < reader.FieldCount; i++)
        {
            if (reader[i] == reader["Comment"])
            {
                label2.Text = reader.GetSqlString(i).IsNull ? null : reader.GetSqlString(i).Value;
            }
            else
            {
                // add to array
                qc[i] = reader.GetValue(i);
            }
        }
        label1.Text = string.Join("|", qc.OfType<string>());
    }
