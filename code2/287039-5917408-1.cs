    static int? Bytes2IntViaSQL( byte[] @bytes )
    {
      int? value ;
      const string connectionString = "Data Source=localhost;Initial Catalog=sandbox;Integrated Security=SSPI;" ;
      using ( SqlConnection connection = new SqlConnection( connectionString ) )
      using ( SqlCommand    sql        = connection.CreateCommand() )
      {
        sql.CommandType = CommandType.StoredProcedure ;
        sql.CommandText = "dbo.pConvertBytesToInt" ;
                
        SqlParameter p1 = new SqlParameter( "@bytes" , SqlDbType.VarBinary ) ;
        if ( @bytes == null ) { p1.Value = System.DBNull.Value ; }
        else                  { p1.Value = @bytes              ; }
                
        sql.Parameters.Add( p1 ) ;
               
        connection.Open() ;
        object result = sql.ExecuteScalar() ;
        value = result is DBNull ? (int?)null : (int?)result ;
        connection.Close() ;
        
      }
      
      return value ;
    }
