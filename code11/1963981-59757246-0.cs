	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Globalization;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Converters;
	namespace QuickType
	{
		public partial class Request
		{
			[JsonProperty("status")]
			public string Status { get; set; }
			[JsonProperty("value")]
			public ValueElement[][] Value { get; set; }
		}
		public partial class ValueClass
		{
			[JsonProperty("role")]
			public string Role { get; set; }
			[JsonProperty("company")]
			public string Company { get; set; }
			[JsonProperty("first_name")]
			public string FirstName { get; set; }
			[JsonProperty("last_name")]
			public string LastName { get; set; }
			[JsonProperty("modification_date")]
			public DateTimeOffset ModificationDate { get; set; }
		}
		public partial struct ValueElement
		{
			public string String;
			public ValueClass ValueClass;
			public static implicit operator ValueElement(string String) => new ValueElement { String = String };
			public static implicit operator ValueElement(ValueClass ValueClass) => new ValueElement { ValueClass = ValueClass };
		}
		internal static class Converter2
		{
			public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
			{
				MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
				DateParseHandling = DateParseHandling.None,
				Converters =
				{
					ValueElementConverter.Singleton,
					new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
				},
			};
		}
		internal class ValueElementConverter : JsonConverter
		{
			public override bool CanConvert(Type t) => t == typeof(ValueElement) || t == typeof(ValueElement?);
			public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
			{
				switch (reader.TokenType)
				{
					case JsonToken.String:
					case JsonToken.Date:
						var stringValue = serializer.Deserialize<string>(reader);
						return new ValueElement { String = stringValue };
					case JsonToken.StartObject:
						var objectValue = serializer.Deserialize<ValueClass>(reader);
						return new ValueElement { ValueClass = objectValue };
				}
				throw new Exception("Cannot unmarshal type ValueElement");
			}
			public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
			{
				var value = (ValueElement)untypedValue;
				if (value.String != null)
				{
					serializer.Serialize(writer, value.String);
					return;
				}
				if (value.ValueClass != null)
				{
					serializer.Serialize(writer, value.ValueClass);
					return;
				}
				throw new Exception("Cannot marshal type ValueElement");
			}
			public static readonly ValueElementConverter Singleton = new ValueElementConverter();
		}
	}
