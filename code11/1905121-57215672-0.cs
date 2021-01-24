    private DataSet GetData(string SPName, object selectedDivision)
        {
            string CS = ConfigurationManager.ConnectionStrings["ConnString1"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter(SPName, con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@Division",
                    Value = selectedDivision
                };
            da.SelectCommand.Parameters.Add(parameter);
            DataSet DS = new DataSet();
            da.Fill(DS);
            return DS;
        }
