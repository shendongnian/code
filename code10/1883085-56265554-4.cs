	public class Entity
	{
		[JsonConverter(typeof(NullJsonConverter))]
		public HasValue<int?> Number { get; set; }
	}
