    private bool DeleteRow(DateTime myDate, string myName)
    {
        connection.Open();
        using (var cmd = new OleDbCommand("DELETE * FROM YourTable WHERE MyDate = ? AND MyName = ?", connection))
        {
            cmd.Parameters.Add(new OleDbParameter
            {
                ParameterName = "@MyDate",
                DbType = DbType.DateTime,
                Value = myDate
            });
            cmd.Parameters.Add(new OleDbParameter
            {
                ParameterName = "@MyName",
                DbType = DbType.String,
                Value = myName
            });
            return (cmd.ExecuteNonQuery() == 1);
        }
    }
