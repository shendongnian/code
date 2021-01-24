    // Define it as a new SqlParameter first...
    SqlParameter Id = new SqlParameter("@Id", SqlDbType.VarChar);
    Id.Value = StudentId;
    // ...and only then, add it:
    cmd.Parameters.Add(Id);
    SqlCommand cmd = dm.RunQuery(sqlquery);
   
    
