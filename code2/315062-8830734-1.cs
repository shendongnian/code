    private void ShowPossiblePurchases(string categoryName)
    {
        if (!String.IsNullOrEmpty(categoryName))
        {
            try
            {
                string connString = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
                SqlConnection connection = new SqlConnection(connString);
                string commandText = "SELECT TOP 2 * FROM Menu WHERE CategoryName=@CategoryName ORDER BY NEWID()";
                using (connection)
                {
                    using (SqlCommand command = new SqlCommand(commandText, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryName", categoryName);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        GridView1.DataSource = table;
                        GridView1.DataBind();
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Label lblError = (Label)Page.FindControl("lblError");
                lblError.Text = ex.Message;
            }
        }
    }
