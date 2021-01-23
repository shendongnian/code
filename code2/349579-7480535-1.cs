	public List<Task> GetTasksByAssignedTo<P>(
		Guid contactId,
		Expression<Func<Task, P>> orderBy)
	{
		return dc.Tasks
			.Where(x => x.ContactId == contactId)
			.OrderBy(orderBy)
			.ToList(); // Now execution happens here
	}
