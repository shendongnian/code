                   using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conLocal))
                   using (SqlDataReader readerLocal = readLocal.ExecuteReader())
                    {
                        while (readerLocal.Read())
                        {
                            bulkCopy.WriteToServer(readerLocal);
                        }
                    }  
