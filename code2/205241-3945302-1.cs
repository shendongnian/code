      using(SqlConnection connection = new SqlConnection("context connection=true")) 
      {
         // Create the record and specify the metadata for the columns.
         // This record describes a result with two columns:
         //  Name NVARCHAR(4000)
         //  URL VARCHAR(4000)
         //
         SqlDataRecord record = new SqlDataRecord(
           new SqlMetaData("Name", SqlDbType.NVarChar, 4000),
           new SqlMetaData("URL", SqlDbType.VarChar, 4000),
           ...);
         // Mark the begining of the result-set.
         SqlContext.Pipe.SendResultsStart(record);
         connection.Open();
         SqlCommand command = new SqlCommand("select Name, Picture from myTable", connection);
         using (SqlDataReader rdr = command.ExecuteReader())
         {
            while(rdr.Read ())
            {
                // Transform the current row from rdr into the target record
                string nameDb = rdr.GetString(0);
                string urlDb = rdr.GetString(1);
                // do the transformations:
                string nameResult = String.Format("<h2>{0}</h2>", nameDb);
                string awt = ComputeTheAWT(urlDb);
                string urlResult = FormatURL (urlDb, awt);
                // Assign the record properties
                record.SetString(0, nameResult);
                record.SetString(1, urlResult);
                // send the record
                SqlContext.Pipe.SendResultsRow(record);
            }
         }
         SqlContext.Pipe.SendResultsEnd ();
      }
