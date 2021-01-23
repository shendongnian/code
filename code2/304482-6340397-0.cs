    string query;
    using(var sqlCommand = new SqlCommand(
        "select query from Table1 where syntax=@syntax", conn))
    {
        sqlCommand.Parameters.AddWithValue("syntax", textBox1.Text);
        query = (string)sqlCommand.ExecuteScalar();
    }
    
    using(var dataAdapter = new SqlDataAdapter())
    using(var dataCommand = new SqlCommand(query, conn))
    {
        dataCommand.Parameters.AddWithValue("parameter", poNumber);
        dataAdapter.SelectCommand = dataCommand;
        dataAdapter.Fill(myDataSet);
    }
