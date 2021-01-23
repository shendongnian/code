     using ( SqlConnection conn = new SqlConnection( "connection string" )
        {
          conn.Open();
    
          string selstr = "SELECT COUNT(*) FROM test3 WHERE PostID = @bleh";
          SqlCommand cmd = new SqlCommand( selstr, conn );
          SqlParameter name = cmd.Parameters.Add( "@bleh", SqlDbType.NVarChar, 255 );
          name.Value = "value";
          int count = cmd.ExecuteScalar();
          //Do you stuff
       }
