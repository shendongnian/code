    string connString= // connection string to your SQL database, left as an exercise for the reader
    string sql = "SELECT MAX(TRADE_DATE) FROM tblModels WHERE [MODEL] = @CompanyName";
    using (SqlConnection conn = new SqlConnection(connString))
    {
        conn.Open();
        using (SqlCommand cmd = new SqlCommand(sql, conn)),
        {
            cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = Symbol.SymbolInformation.CompanyName;
            object scalar = cmd.ExecuteScalar();
            var maxTradeDate=(DateTime)scalar; // I'm assuming trade_date is a datetime,datettime2 or date.
        }
    }
