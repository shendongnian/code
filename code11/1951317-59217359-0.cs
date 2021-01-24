	public enum EventType
	{
		Data,
		BeginGroup,
		EndGroup,
		Group
	}
	
	public class Event<T>
	{
		public Event(int id, EventType type, T data)
		{
			this.Id = id;
			this.Type = type;
			this.Data = data;
		}
		
		public int Id { get; set; }
		public EventType Type { get; set; }
		public T Data { get; set;}
	}
	
	public class GroupEvent<T> : Event<T> {
		public GroupEvent(int id, IEnumerable<Event<T>> events)
			: base(id, EventType.Group, default(T))
		{
			this.ChildData = events;
		}
	
		public IEnumerable<Event<T>> ChildData { get; set; }
	}
