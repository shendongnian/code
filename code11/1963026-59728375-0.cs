var acc = new Microsoft.Azure.Cosmos.Table.CloudStorageAccount(
                         new StorageCredentials("account name", "account key"), true);
            var tableClient = acc.CreateCloudTableClient();
            var table = tableClient.GetTableReference("table name");
            TableContinuationToken token = null;
            var entities = new List<MyEntity>();
            do
            {
                var queryResult = table.ExecuteQuerySegmented(new TableQuery<MyEntity>(), token);
                entities.AddRange(queryResult.Results);
                token = queryResult.ContinuationToken;
            } while (token != null);
