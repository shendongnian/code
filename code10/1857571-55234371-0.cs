    string sql = "SELECT * FROM Customers WHERE LastName = @lastName AND FirstName = @firstName";
            UserAccount account = UserAccount.Empty;
            using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
            {
                SqlParameter _firstName = new SqlParameter("@firstName", SqlDbType.NVarChar);
                SqlParameter _lastName = new SqlParameter("@lastName", SqlDbType.NVarChar);
                _firstName.Value = account.FirstName;
                _lastName.Value = account.LastName;
                cmd.Parameters.Add(_firstName);
                cmd.Parameters.Add(_lastName);
                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataSet);
                if (dataSet.Tables.Count > 0)
                {
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        DataRow row = dataSet.Tables[0].Rows[0];
                        //fill your properties with the results
                    }
                }
                adapter.Dispose();
                dataSet.Dispose();
            }
