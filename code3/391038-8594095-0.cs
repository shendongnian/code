    var context = CreateNewContext();
    
                context.IgnoreResourceNotFoundException = true;
    
                if (context.StorageCredentials.AccountName == "devstoreaccount1")
                {
                    var entityCheck = context.CreateQuery<SmartTableServiceEntity>(tableName)
                        .Where(e => e.PartitionKey == partitionKey && e.RowKey == rowKey).FirstOrDefault();
    
                    if (entityCheck == null) {
                        context.AddObject(tableName, smartEntity);
                    }
                    else  {
                        context.Detach(entityCheck);
                        context.AttachTo(tableName, smartEntity, "*");
                        context.UpdateObject(smartEntity);
                    }
                }
                else 
                {
                    context.AttachTo(tableName, smartEntity, null);
                    context.UpdateObject(smartEntity);
                }
                context.SaveChangesWithRetries(SaveChangesOptions.ReplaceOnUpdate);
