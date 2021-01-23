    //_assumes the following using statements at the top of code file:_
    //using System.Data;
    //using System.Data.SqlClient;
         public string getTeam(int CityID)
              {
                 string name;
        
                 using (var cmd = new SqlCommand("foo1",new SqlConnection("myConnectionStringGoesHere")))
                 {
                    cmd.Parameters.Add(new SqlParameter("@param", CityID));
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.BigInt){Direction=ParameterDirection.Output});
                    cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar,50) { Direction = ParameterDirection.Output });
        
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    
                    name = cmd.Parameters["@name"].Value.ToString();
                    
                    cmd.Connection.Close();
        
                 }
        
                 return name;
              }
