    using (SqlDataReader reader = ocom.ExecuteReader())
    {
      while (reader.Read())
      {           
      }
    } 
    SqlCacheDependency SqlDep = new SqlCacheDependency(ocom);
    aggDep.Add(SqlDep);
