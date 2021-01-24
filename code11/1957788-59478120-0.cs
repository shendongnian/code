    private static DataTable getTable1(DateTime startDate, DateTime endDate)
    {
        string constr = ConfigurationManager.ConnectionStrings["db_Demo"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Table1 WHERE RefDate between @startDate and @endDate"))
            {
                var startDateParameter = new SqlParameter("@startDate", SqlDbType.DateTime);
                startDateParameter.Value = startDate;
                var endDateParemeter = new SqlParameter("@endDate", SqlDbType.DateTime);
                endDateParemeter.Value = endDate;
                cmd.Parameters.Add(startDateParameter);
                cmd.Parameters.Add(endDateParemeter );
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    DataTable dt = new DataTable();
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                    return dt;
                }
            }
        }
    }
