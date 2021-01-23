        // untested, ought to work
        FbDataReader DBReader = null;
        try
        {
            DBReader = FBC.ExecuteReader();
        }
        catch (Exception e)
        {
            Log.ErrorException("Database Execute Reader Exception", e);
            throw;
        }
        using (DBReader)
        {
          foreach (DbDataRecord record in DBReader) // errors here won't be logged
            yield return record;  
        }
