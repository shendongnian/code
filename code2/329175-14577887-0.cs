	public class Priority
	{
		public Priority()
		{}
		protected Priority(short id, string name)
		{
			Id = id;
			Name = name;
		}
		public short Id { get; set; }
		public string Name { get; set; }
		public static readonly Priority Unknown = new Priority(0, "Unknown");
		public static readonly Priority Optional = new Priority(1, "Optional");
		public static readonly Priority Low = new Priority(2, "Low");
		public static readonly Priority Normal = new Priority(3, "Normal");
		public static readonly Priority High = new Priority(4, "High");
		public static readonly Priority Critical = new Priority(5, "Critical");
		public static readonly Priority Blocking = new Priority(6, "Blocking");
	}
