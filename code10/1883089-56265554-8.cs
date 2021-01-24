	public struct HasValue<T> : IHasValue
	{
		// Had to convert to c# 4.0 syntax for dotnetfiddle
		T m_value;
		public HasValue(T value) { this.m_value = value; }
		public T Value { get { return m_value; } set { m_value = value; } }
		
		public object GetValue() { return Value; }
	}
	internal interface IHasValue
	{
		object GetValue();
	}
	public class NullJsonConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType) { throw new NotImplementedException(); }
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var valueType = objectType.GetGenericArguments()[0];
			var valueValue = serializer.Deserialize(reader, valueType);
			return Activator.CreateInstance(objectType, valueValue);
		}
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			serializer.Serialize(writer, ((IHasValue)value).GetValue());
		}
	}
