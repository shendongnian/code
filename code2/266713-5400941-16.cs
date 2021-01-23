    // Written from my laptop straight into the textarea... so, it's untested.
    public DataTable GetPersonsByIDs(int[] personIDs)
    {
        var dtResults = new DataTable();
        var dtPersonIDs = new DataTable();
        dtPersonIDs.Columns.Add("IntegerValue", typeof(int));
        
        foreach(int id in personIDs)
        {
            dtPersonIDs.Rows.Add(id);
        }
     
        using(dtPersonIDs)
        using(var cnx = new SqlConnection("YourConnectionString"))
        using(var cmd = new SqlCommand {
            Connection = cnx,
            CommandText = "dbo.GetPersonsByIDs",
            CommandType = CommandType.StoredProcedure,
            Parameters = {
                new SqlParameter {
                    ParameterName = "PersonIDs",
                    SqlDbType = SqlDbType.Structured, // must be structured
                    Value = dtPersonIDs,
                }
            }
        })
        { 
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
    }
