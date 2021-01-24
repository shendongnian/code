	public static Query AddRangeFilter(this Query query, string fieldName, IEnumerable<int> validAlternatives)
	{
		if (!validAlternatives.Any())
			return query;
		var booleanQuery = new BooleanQuery { MinimumNumberShouldMatch = 1 };
		foreach (var alternative in validAlternatives)
		{
			var thing = NumericRangeFilter.NewIntRange(fieldName, 1, alternative, alternative, true, true);
			booleanQuery.Add(new FilteredQuery(query, thing), Occur.SHOULD);
		}
		return booleanQuery;
	}
