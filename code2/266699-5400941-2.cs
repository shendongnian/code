    using(SqlConnection cnx = new SqlConnection("YourConnectionString")
    using(SqlCommand cmd = new SqlCommand("GetPersonsByIDs", cnx) { CommandType = CommandType.StoredProcedure})
    using(DataTable dtResults = new DataTable())
    { 
        cmd.Parameters.Add(new SqlParameter("PersonIDs", dtPersonIDs) { SqlDbType = SqlDbType.Structured });
        try
        {
            cnx.Open();
            dt.Load(cmd.ExecuteReader());
            return dtResults;
        }
        catch(Exception ex)
        {
            throw new Exception("Error executing GetPersonsByIDs.", ex);
        }
    }
    // still working one sec
