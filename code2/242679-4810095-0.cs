    public int Exec(  int? @iPatientID )
    {
      using ( SqlConnection  conn = new SqlConnection( this.ConnectString ) )
      using ( SqlCommand     cmd  = conn.CreateCommand() )
      using ( SqlDataAdapter sda  = new SqlDataAdapter( cmd ) )
      {
        cmd.CommandText = STORED_PROCEDURE_NAME ;
        cmd.CommandType = CommandType.StoredProcedure ;
        
        if ( this.TimeoutInSeconds.HasValue )
        {
          cmd.CommandTimeout = this.TimeoutInSeconds.Value ;
        }
        
        //
        // 1. @iPatientID
        //
        SqlParameter p1 = new SqlParameter( @"@iPatientID" , SqlDbType.Int ) ;
        if ( @iPatientID == null )
        {
          p1.Value = System.DBNull.Value ;
        }
        else
        {
          p1.Value = @iPatientID ;
        }
        cmd.Parameters.Add( p1 ) ;
        
        // add return code parameter
        SqlParameter pReturnCode = new SqlParameter() ;
        pReturnCode.SqlDbType    = System.Data.SqlDbType.Int ;
        pReturnCode.Direction    = System.Data.ParameterDirection.ReturnValue ;
        cmd.Parameters.Add( pReturnCode ) ;
        
        DataSet ds = new DataSet() ;
        
        conn.Open() ;
        sda.Fill( ds ) ;
        conn.Close() ;
        
        this.ResultSet  = ( ds.Tables.Count > 0 ? ds.Tables[0] : null ) ;
        this.ReturnCode = (int) pReturnCode.Value ;
      }
      
      return this.ReturnCode ;
      
    }
