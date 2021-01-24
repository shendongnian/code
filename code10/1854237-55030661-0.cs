    private void enterdetails_Click(object sender, EventArgs e)
    {
        string query = "INSERT INTO tbl_register([email],[password]) VALUES(@email,@password)";
			
        using(SqlConnection sqlconn = new SqlConnection(@""))
        using(SqlCommand comm = new SqlCommand(query, sqlconn))
		{
			sqlconn.Open();
			comm.Parameters.Add("@email", SqlDbType.VarChar, 200).Value = mail.Text
			comm.Parameters.Add("@password", SqlDbType.VarBinary, 256).Value = Hashing.ComputeHash(pass.Text,  Supported_HA.SHA256, ASCIIEncoding.ASCII.GetBytes("Supported_HA.SHA256"));
			
			comm.ExecuteNonQuery();
		}
    }
