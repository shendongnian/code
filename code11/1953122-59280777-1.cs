    using (var pgConn = new NpgsqlConnection(myPgConnStr))
    {
        using (var writer = pgConn.BeginBinaryImport("COPY " + destinationTableName + " (" + commaSepFieldNames + ") FROM STDIN (FORMAT BINARY)"))
        {
            //Loop through data
            for (int i = 0; i < endNo; i++)
            {
                writer.StartRow();
                
                //inner loop through fields
                for (int j = 0; j < fieldNo; j++)
                {
    
                    //test for null
                    if (true)
                    {
                        writer.WriteNull();
                    }
                    else
                    {
                        //Write data using column types
                        writer.Write(value, type);
                    }
                }
            }
            writer.Complete();
        }
    }
