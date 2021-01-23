     protected void submit_onclick(object sender, EventArgs e)
     {
         string sqlStmt = "INSERT INTO dbo.YourTable(documentTitle, documentBody)  " + 
                          "VALUES(@docTitle, @docBody)";
         string connectionString = WebConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;
         using(SqlConnection conn = new SqlConnection(connectionString))
         using(SqlCommand cmd = new SqlCommand(sqlStmt, conn))
         {
            cmd.Parameters.Add("@docTitle", SqlDbType.VarChar, 100).Value = tbxTitle.Text.Trim();
            cmd.Parameters.Add("@docBody", SqlDbType.VarChar, 100).Value = tbxBody.Text.Trim();
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
         }
     }
