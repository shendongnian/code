	var translationsQuery = new TableQuery<T>()
	.Where(TableQuery.CombineFilters(
	TableQuery.CombineFilters(
		TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, sourceDestinationPartitionKey),
		TableOperators.Or,
		TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, anySourceDestinationPartitionKey)
		),
	TableOperators.And,
	TableQuery.CombineFilters(
		TableQuery.GenerateFilterConditionForDate("affectiveAt", QueryComparisons.LessThan, DateTime.Now),
		TableOperators.And,
		TableQuery.GenerateFilterConditionForDate("expireAt", QueryComparisons.GreaterThan, DateTime.Now))
	));
	
