	public List<Task> GetTasksByAssignedTo<P>(Guid contactId, Func<Task, P> orderBy)
	{
		return dc.Tasks
			.Where(x => x.ContactId == contactId)
			.OrderBy(orderBy) // this forces evaluation - sort happens in memory
			.ToList();
	}
