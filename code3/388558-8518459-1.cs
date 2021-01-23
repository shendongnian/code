      SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Northwind_ConnectionString"].ConnectionString);
     
            //Create Command object
            SqlCommand nonqueryCommand = thisConnection.CreateCommand();
     
            try
            {
                // Open Connection
                thisConnection.Open();
     
                // Create INSERT statement with named parameters
                nonqueryCommand.CommandText = "INSERT  INTO Employees (FirstName, LastName) VALUES (@FirstName, @LastName)";
     
                // Add Parameters to Command Parameters collection
                nonqueryCommand.Parameters.Add("@FirstName", SqlDbType.VarChar, 10);
                nonqueryCommand.Parameters.Add("@LastName", SqlDbType.VarChar, 20);
     
     
                nonqueryCommand.Parameters["@FirstName"].Value = txtFirstName.Text;
                nonqueryCommand.Parameters["@LastName"].Value = txtLastName.Text;
     
                nonqueryCommand.ExecuteNonQuery();
            }
     
            catch (SqlException ex)
            {
                // Display error
                lblErrMsg.Text = ex.ToString();
                lblErrMsg.Visible = true;
            }
     
            finally
            {
                // Close Connection
                thisConnection.Close();
     
            }
