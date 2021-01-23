    public DataTable GetAlertsByDate(DateTime start, DateTime end)
    {
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(
            "SELECT * FROM Alerts WHERE EventTime BETWEEN @start AND @end", conn);
        DataTable table = new DataTable();
        try
        {
            SqlParameter param;
            param = new SqlParameter("@start", SqlDbType.DateTime);
            param.Value = start;
            cmd.Parameters.Add(param);
            param = new SqlParameter("@end", SqlDbType.DateTime);
            param.Value = end;
            cmd.Parameters.Add(param);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);
        }
        finally
        {
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
        }
        return table;
    }
