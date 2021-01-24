	// preparing the query
	var groupIds = new[] { 200, 201 };
	Func<QueryContainerDescriptor<Brand>, int, QueryContainer> nestedQuery = (q, groupId) => q.Nested(n => n.Path("Groups").Query(nq => nq.Bool(nb => nb.Filter(
			fq => fq.Term(t => t.Field("Groups.GroupId").Value(groupId)),
			fq => fq.Term(t => t.Field("Groups.IsActive").Value(true))))
		)
	);
	var query = groupIds.Select(groupId => nestedQuery(new QueryContainerDescriptor<Brand>(), groupId)).ToList();
	query.Add(new QueryContainerDescriptor<Brand>().Match(m => m.Field("Name").Fuzziness(Fuzziness.Auto).Query("coke")));
	var queryDescriptor = new QueryContainerDescriptor<Brand>();
	queryDescriptor.Bool(b => b.Must(query.ToArray()));
