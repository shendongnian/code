     // ConnectionString make it globle access inside this class
        private string ConnectionString = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString;
    
        protected void PopulateReviewerDDL()
        {
            // Currently logged in user:  
            var iUserName = GetCurrentUser();
    
            try
            {
                var reviewerName = GetReviewerName(iUserName, ConnectionString);
    
                if(reviewerName != null)
                {
                    lblUserName.Text = reviewerName;
    
                    if (!ddlReviewerName.Items.FindByText(reviewerName) == null)
                        ddlReviewerName.Text = reviewerName;
                    else
                        Response.Redirect("NoAccess.htm", false);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    
        protected string GetCurrentUser()
        {
            return Right(Request.ServerVariables("AUTH_USER"), (Request.ServerVariables("AUTH_USER").Length - 6));
        }
    
        protected string GetReviewerName(string username, string connectionString)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("Username or ConnectionString is Empty");
    
            string fullName = null;
    
            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand("SELECTADISNames", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    command.Parameters.Add("@LogonName", SqlDbType.VarChar).Value = username;
    
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fullName = reader["FirstName"].ToString() + " " + LastName = reader["LastName"].ToString();
                        }
                    }
    
                }
            }
            catch (SqlException ex) // we need to catch sql errors only 
            {
                throw new Exception(ex.Message);
            }
    
            return fullName;
        }
