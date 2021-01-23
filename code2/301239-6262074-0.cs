       bool TestConnection()
       {
           SqlConnection conn = new SqlConnection(string.Format(@"user id={0}; password={1};Data Source={2}; 
                                       Trusted_Connection=yes;
                                       Initial Catalog={3}; 
                                       connection timeout=30", userName,password,serverName,database));
           try
           {
               conn.Open();
               return true;
           }
           catch (Exception e)
           {
               return false;
           }
       }
