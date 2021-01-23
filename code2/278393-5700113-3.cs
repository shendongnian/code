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
            DataSet ds = new DataSet(); 
            da.Fill(ds);
            
            // Set the names of the tables in the dataset
            string strTableNames = cmd.Parameters["@tableNames"].Value.ToString();
            string[] tableNames = strTableNames.split(',');
            for (int i=0; i<tableNames.Length; i++)
            {
                ds.Tables[i].TableName = tableNames[i];
            }
        }
