      using(SqlConnection connection = new SqlConnection("context connection=true")) 
      {
         // Create the record and specify the metadata for the columns.
         SqlDataRecord record = new SqlDataRecord(
           new SqlMetaData("...", SqlDbType...., ...),
           ...);
         // Mark the begining of the result-set.
         SqlContext.Pipe.SendResultsStart(record);
         connection.Open();
         SqlCommand command = new SqlCommand("select * from myTable", connection);
         using (SqlDataReader rdr = command.ExecuteReader())
         {
            while(rdr.Read ())
            {
                // Transform the current row from rdr into the target record
                record.Set...(0, r.Get...(...));
                record.Set...(..., r.Get...(...));
                // send the record
                SqlContext.Pipe.SendResultsRow(record);
            }
         }
         SqlContext.Pipe.SendResultsEnd ();
      }
