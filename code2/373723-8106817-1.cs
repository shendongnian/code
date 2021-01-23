        bulkCopy.DestinationTableName = "dbo.TableYouWantToInsertTheRowsTo";
    
        try
        {
             // Write from the source to the destination.
             bulkCopy.WriteToServer(newProductsDataTable);
        }
        catch (Exception ex)
        {
             Console.WriteLine(ex.Message);
        }
    }
