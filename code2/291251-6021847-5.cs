    protected void Page_Load(object sender, EventArgs e)
    {
        string x = Request.QueryString["SubId"];
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        using (var conn = new SqlConnection(connectionString))
        using (var cmd = conn.CreateCommand())
        {
            conn.Open();
            cmd.CommandText = "SELECT ProductId FROM SubmissionProducts WHERE SubmissionId = @SubmissionId";
            cmd.Parameters.AddWithValue("@SubmissionId", x)
    
            using (var reader = cmd.ExecuteReader())
            {
                while (Ddldr.Read())
                {
                    switch (reader.GetInt32(reader.GetOrdinal("ProductId")))
                    {
                        ... your cases here
                        default:
                            break;
                    }
                }
    
            }
        }
    }
