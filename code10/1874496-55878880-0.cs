	var where = "";
	var ordering = "";
	if (eventType.Equals("consert"))
	{
		where = "Published and PublishType =\"Consert\"";
		ordering = "PublishStart";
	}
	else if (eventType.Equals("last-chance"))
	{
		where = "Published";
		ordering = "PublishEnd";
	}
	newItemList = itemList.AsQueryable() // this is in order to enable Dynamic.Linq
		.Where(where)
		.OrderBy(ordering)
		.ToList();   
  
But as others pointed, you might not need this, since the `IEnumerable` interface is composable, in the way that you can decide what put in the Where clauses without actually running them.
	IEnumerable<Event> newItems = itemList;
	if (eventType.Equals("consert"))
	{
		newItems = newItems.Where(c => c.Published && c.PublishType == EventType.Consert);
	}
	else if (eventType.Equals("last-chance"))
	{
		newItems = newItems.Where(c => c.Published);
	}
	if (eventType.Equals("consert"))
	{
		newItems = newItems.OrderBy(c => c.PublishStart);
	}
	else if (eventType.Equals("last-chance"))
	{
		newItems = newItems.OrderBy(c => c.PublishEnd);
	}
	var newItemsList = newItems.ToList(); // newItems holds references to the expressions and the .ToList() call will parse and execute them at this moment
This duplication might be annoying thus you have also the option to use `Func`.
	IEnumerable<Event> newItems = itemList;
	Func<Event, DateTime> orderBy = null;
	if (eventType.Equals("consert"))
	{
		newItems = newItems.Where(c => c.Published && c.PublishType == EventType.Consert);
		orderBy = c => c.PublishStart;
	}
	else if (eventType.Equals("last-chance"))
	{
		newItems = newItems.Where(c => c.Published);
		orderBy = c => c.PublishEnd;
	}
	if (orderBy != null)
	{
		newItems = newItems.OrderBy(orderBy);
	}
	var newItemsList = newItems.ToList(); // newItems holds references to the expressions and the .ToList() call will parse and execute them at this moment 
  [1]: https://www.nuget.org/packages/System.Linq.Dynamic.Core/
