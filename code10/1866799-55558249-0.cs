            var storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=account-name;AccountKey=acccount-key;EndpointSuffix=core.windows.net;");
            var client = storageAccount.CreateCloudTableClient();
            var table = client.GetTableReference("test");
            var partitionKey = "test";
            var rowKey = "bob";
            var valueToCheck = "119";
            var insertOrMergeEntity = true;
            var op = TableOperation.Retrieve(partitionKey, rowKey);
            var result = table.Execute(op);
            var entity = result.Result as DynamicTableEntity;
            if (entity == null)
            {
                entity = new DynamicTableEntity(partitionKey, rowKey);
            }
            if (entity.Properties.ContainsKey("number"))
            {
                var numberAttributeValue = entity.Properties["number"].StringValue;
                if (numberAttributeValue.IndexOf(valueToCheck) < 0)
                {
                    numberAttributeValue += "; " + valueToCheck;
                    entity.Properties["number"] = new EntityProperty(numberAttributeValue);
                }
                else
                {
                    insertOrMergeEntity = false;
                }
            }
            else
            {
                entity.Properties.Add("number", new EntityProperty(valueToCheck));
            }
            if (insertOrMergeEntity)
            {
                var mergeOperation = TableOperation.InsertOrMerge(entity);
                table.Execute(mergeOperation);
            }
