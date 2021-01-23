    SqlConnection c= new SqlConection ( connectionstring );
    c.Open();
    SqlCommand cmd = new SqlCommand ("sp_MyBackup", c);
    cmd.CommadType = CommandType.StoredProcedure;
    cmd.ExecuteNonQuery();
    c.Close();
