    public string connectionString = @"Data Source='soursename';Initial Catalog=clg;User ID=sa;Password='pass'";
    using(SqlConnection MSSQL = new SqlConnection(connectionString))
    {
         MSSQL.Open();
         string query = @"INSERT INTO Student (s_id, s_name, s_class, s_email) 
                          VALUES (@s_id, @s_name, @s_class, @s_email);";
    
         // Create the command AND the parameters outside the loop
         SqlCommand cmd1 = new SqlCommand(query, MSSQL);
         cmd1.Parameters.Add("@s_id", SqlDbType.NVarChar);
         cmd1.Parameters.Add("@s_name", SqlDbType.NVarChar);
         cmd1.Parameters.Add("@s_class", SqlDbType.NVarChar);
         cmd1.Parameters.Add("@s_email", SqlDbType.NVarChar);
         foreach (DataRow row in mySqlTable.Rows)
         {
            cmd1.Parameters["@s_id"].Value = row[0];
            cmd1.Parameters["@s_name"].Value = row[1];
            cmd1.Parameters["@s_class"].Value = row[2];
            cmd1.Parameters["@s_email"].Value = row[3];
            cmd1.ExecuteNonQuery();
        }
    }
