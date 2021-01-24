 CloudStorageAccount account = CloudStorageAccount.Parse(connectionStr);
            var client =account.CreateCloudTableClient(new TableClientConfiguration());
            var table =client.GetTableReference("people");
            string date1 = TableQuery.GenerateFilterConditionForDate(
                   "Timestamp", QueryComparisons.GreaterThanOrEqual,
                   DateTime.Now.AddDays(-1).ToUniversalTime());
            string date2 = TableQuery.GenerateFilterConditionForDate(
                               "Timestamp", QueryComparisons.LessThanOrEqual,
                               DateTime.Now.ToUniversalTime());
            var key = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Jack");
            string filter = TableQuery.CombineFilters(date1, TableOperators.And, date2);
            filter = TableQuery.CombineFilters(filter, TableOperators.And, key);
            var query = new TableQuery<Person>().Where(filter);
            var l = new List<Person>();
            TableContinuationToken continuationToken = null;
            do
            {
                var queryResponse = await table.ExecuteQuerySegmentedAsync(query, continuationToken);
                continuationToken = queryResponse.ContinuationToken;
                l.AddRange(queryResponse.Results);
            }
            while (continuationToken != null);
            foreach (var s in l) {
                Console.WriteLine(s.PartitionKey + "" + s.);
            }
[![enter image description here][1]][1] 
  [1]: https://i.stack.imgur.com/gQyPS.png
