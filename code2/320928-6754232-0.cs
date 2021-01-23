        using System;
        using System.Data;
        using System.Data.SqlClient;
        namespace ConsoleApplication4
        {
            class Program
            {
              static void Main( string[] args )
              {
                string myConnectString = GetConnectionString() ; // your connect string here!
                using ( SqlConnection dbConnection = new SqlConnection( myConnectString ) )
                using ( SqlCommand    sql          = dbConnection.CreateCommand() )
                {
                  sql.CommandType = CommandType.Text ;
                  sql.CommandText = @"
        select t.some_datetime
        from dbo.some_table t
        " ;
                  dbConnection.Open() ;
                  using ( SqlDataReader reader = sql.ExecuteReader() )
                  {
                    while ( reader.Read() )
                    {
                      DateTime someDateTime = reader.GetDateTime(0) ;
                      process( someDateTime.Year , someDateTime.Month , someDateTime.Day ) ;
                    }
                  }
                  dbConnection.Close() ;
                }
        
                return ;
              }
      
              private static void process( int p , int p_2 , int p_3 )
              {
                throw new NotImplementedException();
              }
      
            }
        }
