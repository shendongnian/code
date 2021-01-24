    public void CreateBasicInformation()
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        builder.DataSource = "myServer.database.windows.net";
        builder.UserID = "admin";
        builder.Password = "myPass";
        builder.InitialCatalog = "myDB";
        try
       {
            SqlConnection cn = new SqlConnection(builder.ConnectionString);
            cn.Open();
            SqlCommand cmd = new SqlCommand("Add_Information", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", "34926");
            cmd.Parameters.AddWithValue("@year", "2020");
            // Execute and get rows affected count. 
           var rowsAffected = cmd.ExecuteNonQuery();
            cn.Close();
        }
        catch (SqlException sqlEx)
        {
            Console.WriteLine(sqlEx.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
