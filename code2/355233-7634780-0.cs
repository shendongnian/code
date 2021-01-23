	[DataContract]
	public class PostCrate
	{
		[DataMember(Name = "data")]
		public List<Post> Data { get; set; }
		[DataMember(Name = "paging")]
		public Paging Paging { get; set; }
	}
    [DataContract]
    public class Paging
	{
		[DataMember(Name = "previous")]
		public string Previous { get; set; }
		[DataMember(Name = "next")]
		public string Next { get; set; }
	}
	[DataContract]
	public class Post
	{
		[DataMember(Name = "id")]
		public string ID { get; set; }
		[DataMember(Name = "from")]
		public BaseUser From { get; set; }
		[DataMember(Name = "type")]
		public string Type { get; set; }
		[DataMember(Name = "created_time")]
		public string CreatedTime { get; set; }
		[DataMember(Name = "updated_time")]
		public string UpdatedTime { get; set; }
	}
	[DataContract]
	public class BaseUser
	{
		[DataMember(Name = "id")]
		public string ID { get; set; }
		[DataMember(Name = "name")]
		public string Name { get; set; }
	}
