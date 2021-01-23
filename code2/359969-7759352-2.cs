        // not working
        try
        {
            using (DBReader = FBC.ExecuteReader())
            {
              foreach (DbDataRecord record in DBReader) 
                 yield return record;
            }
        }
        catch (Exception e)
        {
            Log.ErrorException("Database Execute Reader Exception", e);
            throw;
        }
