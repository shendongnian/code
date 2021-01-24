	public class Model
	{
		public StringEnum StringEnum { get; set; }
		
		[JsonConverter(typeof(SerializePropertyAsDefaultConverter<SomeEnumNotToSerializeAsAString>))]
		public SomeEnumNotToSerializeAsAString SomeEnumNotToSerializeAsAString { get; set; }
	}
