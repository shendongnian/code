    private static bool UserToCustomer(User u, Customer c)
        {
            try
            {
                string sqlcommand = "INSERT INTO [dbo].[Customers] ([Id], [Email]) VALUES (" + u.Id + ", '" + c.Email + "')";
                var sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString);
                sqlconn.Open();
                var sql = new SqlCommand(sqlcommand, sqlconn);
                var rows = sql.ExecuteNonQuery();
                sqlconn.Close();
                return rows == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
