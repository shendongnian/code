        using (var sqlCopy = new SqlBulkCopy(connString))  
            {  
              sqlCopy.DestinationTableName = "[Products]";  
              sqlCopy.BatchSize = 500;  
              using (var reader = ObjectReader.Create(prodlist, copyParameters)) 
    
               {  
                            sqlCopy.WriteToServer(reader);  
               }  
           } 
 
