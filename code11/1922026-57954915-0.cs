    SqlCommand command = new SqlCommand("EmpReports", WebConfigurationManager.ConnectionStrings["EmpReportConnectionString"].ToString());
    command.CommandType = CommandType.StoredProcedure;
    command.Parameters.Add("@EmpId", SqlDbType.Int).Value = EmpId;
    command.Parameters.Add("@ManId", SqlDbType.Int).Value = ManId;
    command.ExecuteNonQuery();
