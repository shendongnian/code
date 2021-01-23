    string sqlStmt = "SELECT DateOfBirth FROM dbo.Patients WHERE HealthNumber = @No";
 
    using (SqlConnection con = new SqlConnection(dc.Con))
    using (SqlCommand cmd = new SqlCommand(sqlStmt, con))
    {
       cmd.Parameters.Add("@No", SqlDbType.VarChar, 20).Value = cmbHealthNumber.Text.Trim();
       con.Open();
       var result = cmd.ExecuteScalar();       
       DateTime dateOfBirth = Convert.ToDateTime(result);
       con.Close();
    }
