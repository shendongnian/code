    using Newtonsoft.Json;
    using System.Collections.Generic;
    
	[JsonConverter(typeof(AttributeBagConverter))]
	public class AttributeBag
	{
        //private constructor to make it able to create instance from converter
		private AttributeBag(List<Attribute> attributes)
		{
			this.attributes = attributes;
		}
		public class AttributeBagConverter : JsonConverter<AttributeBag>
		{
			public override AttributeBag ReadJson(JsonReader reader, System.Type objectType, 
                   AttributeBag existingValue, bool hasExistingValue, JsonSerializer serializer)
			{
                //deserialize as List<Attribute> and pass results to private constructor
				return new AttributeBag(serializer.Deserialize<List<Attribute>>(reader));
			}
			public override void WriteJson(JsonWriter writer, AttributeBag value, 
                   JsonSerializer serializer)
			{
                //serialize List<Attribute> only
				serializer.Serialize(writer, value.attributes);
			}
		}
        /* rest of your code */
	}
