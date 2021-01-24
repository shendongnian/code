    public SqlConnection Connection()
        {
          connetionString = @"initial catalog = Test; integrated security = SSPI;    
          data source = KITS13AUG2019-I\JAGDEESH_SQL;";
          conSql = new SqlConnection(connetionString);
          conSql.Open();
    
          return conSql;
        }
