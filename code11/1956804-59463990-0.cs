	public class Person
	{
		public string name { get; set; }
		[BsonIgnore]
		public string dob
		{
			get => BsonExtensionMethods.ToJson(SerializedDOB);
			set => SerializedDOB = MyBsonExtensionMethods.FromJson<Dob>(value);
		}
		[BsonElement("dob")]
		Dob SerializedDOB { get; set; }
		
		class Dob // The DTO
		{
			public string month { get; set; }
			public int day { get; set; }
			public int year { get; set; }
		}
	}
