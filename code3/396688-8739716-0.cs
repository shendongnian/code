    DateTime now = DateTime.Now;
    DateTime after1month = DateTime.Now.AddMonths(1);
    SqlCommand cmd = new SqlCommand("SELECT * FROM TABLE WHERE THEDATE BETWEEN @now AND @after1month", connection);
    cmd.Parameters.Add(new SqlParameter("@now", System.Data.SqlDbType.DateTime).Value = now);
    cmd.Parameters.Add(new SqlParameter("@after1month", System.Data.SqlDbType.DateTime).Value = after1month);
