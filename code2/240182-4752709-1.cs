	public delegate void ObjectCreated(object sender, EventArgs args);
	public delegate void ObjectDeleted(object sender, EventArgs args);
	public event ObjectCreated ObjectWasCreated
	{
		add
		{
			m_ObjectCreatedSubscribers.Add(value.Invoke);
		}
		remove
		{
			m_ObjectCreatedSubscribers.RemoveAll(e => e.Target.Equals(value));
		}
	}
	public event ObjectDeleted ObjectWasDeleted
	{
		add
		{
			m_ObjectDeletedSubscribers.Add(value.Invoke);
		}
		remove
		{
			m_ObjectDeletedSubscribers.RemoveAll(e => e.Target.Equals(value));
		}
	}
	private List<Action<object, EventArgs>> m_ObjectCreatedSubscribers = new List<Action<object, EventArgs>>();
	private List<Action<object, EventArgs>> m_ObjectDeletedSubscribers = new List<Action<object, EventArgs>>();
	void DispatchEvent(List<Action<object, EventArgs>> subscribers, object sender, EventArgs args)
	{
		foreach (var subscriber in subscribers)
			subscriber(sender, args);
	}
