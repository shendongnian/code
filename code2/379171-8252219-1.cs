     string sql = "SELECT [User Type] FROM [Users] where [Name] like @Name";
     SqlCommand cmd = new SqlCommand(sql, conn);
     cmd.Parameters.Add("@Name",SqlDbType.VarChar,50).Value="%" + UserNameList.Text + "%";
     conn.Open();
     SqlDataReader result=cmd.ExecuteReader();
     while(result.Read())
     {
        ///
       }
     result.Close();
     conn.Close();
