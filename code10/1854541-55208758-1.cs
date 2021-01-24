    public class LongRunningTask
    {
      const long pageSize = 100000L; //--> ...or whatever the market will bear
      const int retryLimit = 3;
      public void Start( ConnectionFactory factory, string sql )
      {
        var done = false;
        var page = 0L;
        var index = 0L;
        var retries = 0;
        var retrying = false;
        while ( !done )
        {
          try
          {
            using ( var connection = factory.CreateConnection( ) )
            {
              using ( var cmd = connection.CreateCommand( ) )
              {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.Add( factory.CreateParameter( "@pageSize", SqlDbType.BigInt ) );
                cmd.Parameters.Add( factory.CreateParameter( "@offset", SqlDbType.BigInt ) );
                cmd.Parameters[ "@pageSize" ].Value = pageSize - ( retrying ? index : 0 );
                cmd.Parameters[ "@offset" ].Value = page + ( retrying ? index : 0 );
                connection.Open( );
                using ( var dr = cmd.ExecuteReader( ) )
                {
                  index = retrying ? index : 0;
                  retrying = false;
                  done = !dr.HasRows; //--> didn't get anything, we're done!
                  while ( dr.Read( ) )
                  {
                    //read 1 by 1 record and pass it to algorithm to do some complex processing
                    index++;
                  }
                }
              }
            }
            page++;
          }
          catch ( Exception ex )
          {
            Console.WriteLine( ex );
            if ( retryLimit < retries++ ) throw;
            retrying = true;
          }
        }
      }
    }
    public  class ConnectionFactory
    {
      public DbConnection CreateConnection( )
      {
        return //... a DbConnection
      }
      public DbParameter CreateParameter( string parameterName, SqlDbType type, int length = 0 )
      {
        return //... a DbParameter
      }
    }
