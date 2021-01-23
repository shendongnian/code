    string connection = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\PaddlePower.mdf;Integrated Security=True;User Instance=True";
    object queryResult = null;
    using (SqlConnection cn = new SqlConnection(connection))
    {
        cn.Open(); // Open connection
        // SELECT
        using (SqlCommand cmd = new SqlCommand("SELECT * FROM User WHERE Username = @Username AND Password = @Password", cn))
        {
            cmd.Parameters.AddWithValue("@Username", textBox1.Text);
            cmd.Parameters.AddWithValue("@Password", textBox2.Text);
            queryResult = cmd.ExecuteScalar();
        }
        // INSERT
        using (SqlCommand cmd = new SqlCommand("INSERT INTO [User] (Username, Password) VALUES (@Username, @Password)", cn))
        {
            cmd.Parameters.AddWithValue("@Username", textBox1.Text);
            cmd.Parameters.AddWithValue("@Password", textBox2.Text);
            cmd.ExecuteNonQuery(); // or int affected = cmd.ExecuteNonQuery()
        }
    }
