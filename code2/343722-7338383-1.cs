    public class dbo_SelectAccounts
    {
      public const string STORED_PROCEDURE_NAME = @"dbo.SelectAccounts";
        
      private string   ConnectString    { get ;         set ; }
      public int       ReturnCode       { get ; private set ; }
      public int       TimeoutInSeconds { get ; private set ; }
      public DataTable ResultSet        { get ; private set ; }
      public int       RowCount         { get { return this.ResultSet.Rows.Count ; } }
        
      public int Exec( bool? @fExpired )
      {
        using ( SqlConnection  conn = new SqlConnection( this.ConnectString ) )
        using ( SqlCommand     cmd  = conn.CreateCommand() )
        using ( SqlDataAdapter sda  = new SqlDataAdapter(cmd) )
        {
        
          cmd.CommandText    = STORED_PROCEDURE_NAME;
          cmd.CommandType    = CommandType.StoredProcedure;
          cmd.CommandTimeout = this.TimeoutInSeconds ;
          
          // 1. Format parameter to stored procedure
          SqlParameter p1 = new SqlParameter( @"@fExpired" , SqlDbType.Bit ) ;
          if ( @fExpired == null )
          {
            p1.Value = System.DBNull.Value ;
          }
          else
          {
            p1.Value = @fExpired ;
          }
          cmd.Parameters.Add( p1 );
          // add return code parameter
          SqlParameter pReturnCode = new SqlParameter();
          pReturnCode.SqlDbType    = System.Data.SqlDbType.Int;
          pReturnCode.Direction    = System.Data.ParameterDirection.ReturnValue;
          cmd.Parameters.Add( pReturnCode );
          
          conn.Open();
          sda.Fill( this.ResultSet ) ;
          conn.Close();
          
          this.ReturnCode = (int)pReturnCode.Value;
            
        }
          
        return this.ReturnCode;
      }
      
      #region constructors
      
      public dbo_SelectAccounts( string connectionString , int executionTimeoutInSeconds )
      {
        this.ConnectString    = connectionString          ;
        this.TimeoutInSeconds = executionTimeoutInSeconds ;
        this.ReturnCode       = -1                        ;
        this.ResultSet        = new DataTable()           ;
        return ;
      }
      
      public dbo_SelectAccounts( string connectionString )
      : this( connectionString , 30 )
      {
        this.ConnectString = connectionString;
      }
      
      public dbo_SelectAccounts( SqlConnectionStringBuilder csb , int executionTimeoutInSeconds )
      : this( csb.ConnectionString , executionTimeoutInSeconds )
      {
        return;
      }
      
      public dbo_SelectAccounts( SqlConnectionStringBuilder csb )
      : this( csb.ConnectionString )
      {
        return;
      }
      
      #endregion constructors
      
    }
