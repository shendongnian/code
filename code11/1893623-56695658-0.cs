    while (reader.Read()) {
                Console.Write(reader.GetString(reader.GetOrdinal("FirstName")));
                // display middle name only of not null
                if (!reader.IsDBNull(reader.GetOrdinal("MiddleName")))
                   Console.Write(" {0}", reader.GetString(reader.GetOrdinal("MiddleName")));
                Console.WriteLine(" {0}", reader.GetString(reader.GetOrdinal("LastName")));
             }
