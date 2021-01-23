    /* generated code. do not change -- generated code */
    public class dbo_GetPatientData
    {
      public int     ReturnCode { get ; private set ; }
      public DataRow ResultSet { get ; private set ; }
      public int Exec(  int? @iPatientID )
      {
        using ( SqlConnection  conn = new SqlConnection( this._connectString ) )
        using ( SqlCommand     cmd  = conn.CreateCommand() )
        using ( SqlDataAdapter sda  = new SqlDataAdapter( cmd ) )
        {
          cmd.CommandText = STORED_PROCEDURE_NAME ;
          cmd.CommandType = CommandType.StoredProcedure ;
          
          //
          // 1. @iPatientID
          //
          // required
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
          pReturnCode.SqlDbType = System.Data.SqlDbType.Int ;
          pReturnCode.Direction = System.Data.ParameterDirection.ReturnValue ;
          cmd.Parameters.Add( pReturnCode ) ;
          
          DataSet ds = new DataSet() ;
          
          conn.Open() ;
          sda.Fill( ds ) ;
          conn.Close() ;
          
          DataTable dt    = ( ds.Tables.Count > 0 ? ds.Tables[0] : null ) ;
          this.ResultSet  = ( dt != null && dt.Rows.Count > 0 ? dt.Rows[0] : null ) ;
          this.ReturnCode = (int) pReturnCode.Value ;
          
          
        }
        
        return this.ReturnCode ;
        
      }
      
    }
