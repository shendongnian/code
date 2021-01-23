    using(SqlConnection con = new SqlConnection(Properties.Settings.Default.EventLogPrinterConnectionString))
    using (IDbCommand com = con.CreateCommand())
    {
        con.Open();
        var sql_com_sel = @"SELECT DISTINCT Users, Pages, Date FROM View_lastactiveUser WHERE (Date >= @ds AND Date <= @dp AND Pages > 0) ORDER BY Date";
        com.CommandText = sql_com_sel;
        com.Parameters.Add("@ds", SqlDbType.DateTime).Value = ds;
        com.Parameters.Add("@dp", SqlDbType.DateTime).Value = dp;
        using (IDataReader dr = com.ExecuteReader())
        {
            while (dr.Read())
            {
                users.Add(new UserDemo() { LastActivity = dr["Date"].ToString(), Pages = int.Parse(dr["Pages"].ToString()), User = dr["Users"].ToString() });
            }
            return users;
        }
    }
