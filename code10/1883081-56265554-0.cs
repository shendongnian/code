	public class Entity
	{
		[JsonConverter(typeof(NullJsonConverter))]
		public HasValue<int?>? Number { get; set; }
		
		public bool ShouldSerializeNumber() { return Number.HasValue && Number.Value.Value.HasValue; }
	}
