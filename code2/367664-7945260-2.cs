    public DataSet GetRecords(DateTime dtpFloor,DateTime dtpCeiling)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using (SqlCommand command = conn.CreateCommand())
            {
                string sql = "SELECT * FROM dbo.ClientInvoice WHERE invDate BETWEEN "
                           + "@from AND @to";
                command.CommandText = sql;
                command.Parameters.AddWithValue("@from", dtpFloor");
                command.Parameters.AddWithValue("@to", dtpCeiling");
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                da.Fill(dataSet, "Client");
                return dataSet;
            }
        }
    }
