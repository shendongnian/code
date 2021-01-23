	[DataContract]
	public class ServerUnits
	{
		[DataMember]
		public ServerState State { get; set; }
		[DataMember]
		public List<User> Users { get; set; }
	}
	[DataContract]
	public class ServerState
	{
		[DataMember]
		public string Name { get; set; }
		[DataMember]
		public DateTime Date { get; set; }
	}
	[DataContract]
	public class User
	{
		[DataMember]
		public string login { get; set; }
		[DataMember]
		public string password { get; set; }
	}
