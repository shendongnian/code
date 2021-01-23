	public class NameEnum
	{
		static NameEnum()
		{
			FirstName = new NameEnum("FirstName");
			LastName = new NameEnum("LastName");
		}
		public static NameEnum FirstName { get; private set; }
		public static NameEnum LastName { get; private set; }
		private NameEnum(string name)
		{
			this.Name = name;
		}
		public string Name { get; private set; }
	}
