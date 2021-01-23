    using (SqlConnection = ...)
        {
           // sqlConnection.Open(); // Not really needed. Data Adapter will do this.
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetCustomers_Employees";
            cmd.Connection = sqlConnection;
            // Create the parameter object and add it to the command
            SqlParameter param = new SqlParameter("@tableNames", SqlDbType.VarChar);
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);
            // Get the Data
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            
            // Set the names of the tables in the dataset
            string tableNames = cmd.Parameters["@tableNames"].Value.ToString();
            ds.Tables[0].TableName = tableNames.Split(',')[0];
            ds.Tables[1].TableName = tableNames.Split(',')[1];
        }
