    int GetSum(string no)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = connection.CreateCommand())
        {
            command.CommandText = "select ... where sp_no = @no"; // note the param @no
        
            command.Parameters.AddWithValue("@no", no);
        
            connection.Open();
            return command.ExecuteScalar() as int? ?? 0; // 0 is default value
        }
    }
    
    txtSum.Text = GetSum(txtNo.Text).ToString();
