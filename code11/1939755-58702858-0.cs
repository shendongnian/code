        TableQuery<T> treanslationsQuery = new TableQuery<T>()
         .Where(
          TableQuery.CombineFilters(
            TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, sourceDestinationPartitionKey)
           , TableOperators.Or,
            TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, anySourceDestinationPartitionKey)
          )
         );
