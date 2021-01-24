    private void bindRows()
            {
                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString;
    
                    SqlConnection connection = new SqlConnection(connectionString);
                    connection.Open();
    
                    SqlDataAdapter adapter = new SqlDataAdapter("select id, message from Dropdown", connection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
    
                    DdlRegister.DataSource = ds;
                    DdlRegister.DataTextField = "message";
                    DdlRegister.DataValueField = "id";
                    DdlRegister.DataBind();
                    DdlRegister.Items.Insert(0, new ListItem("I Want", "0"));
                    connection.Close();
                }
                catch (Exception e)
                {
    
                }
            }
