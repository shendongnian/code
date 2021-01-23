     string sql = "SELECT [User Type] FROM [Users] where [Name]=@Name";
     SqlCommand cmd = new SqlCommand(sql, conn);
     cmd.Parameters.Add("@Name",SqlDbType.VarChar,50).Value=UserNameList.Text;
     conn.Open();
     Object result=cmd.ExecuteScalar();
     conn.Close();
     if(result!=null)
      {
         string usertype=result.ToString();
         if(usertype=="Administrator")
           {}
         else
           {}
      }
