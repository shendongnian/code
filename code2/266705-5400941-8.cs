    // Written from my laptop straight into the textarea... so, it's untested.
    public DataTable GetPersonsByIDs(int[] personIDs)
    {
        DataRow dr;
        using(SqlConnection cnx = new SqlConnection("YourConnectionString"))
        using(SqlCommand cmd = new SqlCommand("dbo.GetPersonsByIDs", cnx) { CommandType = CommandType.StoredProcedure})
        using(DataTable dtPersonIDs = new DataTable())
        using(DataTable dtResults = new DataTable())
        { 
            dtPersonIDs.Columns.Add("IntegerValue", typeof(int));
            foreach(int id in personIDs)
            {
                dr = dtPersonIDs.NewRow();
                dr[0] = id;
                dtPersonIDs.Rows.Add(dr);
            }
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
