	public List<Status> GetStatus()
	{
		return Get<Status>(client => client.GetStatus());
	}
	
	public List<Priority> GetPriority()
	{
		return Get<Priority>(client => client.GetPriority());
	}
