    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        string result = "SELECT ACTIVE FROM [dbo].[test] WHERE ID = @id";
        SqlCommand showresult = new SqlCommand(result, conn);
        showresult.Parameters.AddWithValue("id", ID.Text);
        conn.Open();
        ResultLabel.Text = showresult.ExecuteScalar().ToString();
        conn.Close();
    }
