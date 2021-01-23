	public static class TaskEx
	{
		public static IQueryable<Task> WhereAssignedTo(this IQueryable<Task> tasks,
			Guid contactId)
		{
			return tasks.Where(t => t.ContactId == contactId);
		}
		
		public static IQueryable<Task> OrderByName(this IQueryable<Task> tasks)
		{
			return tasks.OrderBy(t => t.Name);
		}
	}
