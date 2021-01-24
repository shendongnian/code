    using (OleDbCommand cmd = new OleDbCommand(formattableString, conn))
    {
        using (OleDbDataReader reader = cmd.ExecuteReader())
        {
            string column = reader.IsDBNull(0) ? null : reader.GetValue(0).ToString();
        }
    }
