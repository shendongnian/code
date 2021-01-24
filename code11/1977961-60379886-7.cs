            var account = CloudStorageAccount.Parse(connectionString);
            
            var requestOptions = new TableRequestOptions()
            {
                LocationMode = LocationMode.SecondaryOnly
            };
            var client = account.CreateCloudTableClient();
            client.DefaultRequestOptions = requestOptions;
            var table = client.GetTableReference("myTable");
            TableQuery query = new TableQuery();
            var result = table.ExecuteQuery(query).ToList();
