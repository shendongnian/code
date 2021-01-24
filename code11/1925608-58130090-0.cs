public sealed class JsonConverterDefaultGuid : JsonConverter<Guid>
{
    public override Guid ReadJson(JsonReader reader, Type objectType, Guid existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        string value = (string)reader.Value;
        return Guid.TryParse(value, out var result) ? result : Guid.Empty; 
    }
    public override void WriteJson(JsonWriter writer, Guid value, JsonSerializer serializer)
    {
        writer.WriteValue(value.ToString());
    }
}
Next - create custom validation attribute witch check if the decorated property has a default value and add a model state error:
public class NotDefaultAttribute : ValidationAttribute
{
    public const string DefaultErrorMessage = "The {0} field must not have default value";
    public NotDefaultAttribute() : base(DefaultErrorMessage)
    {
    }
    public NotDefaultAttribute(string errorMessage) : base(errorMessage)
    {
    }
    public override bool IsValid(object value)
    {
        return !value.Equals(value.GetDefaultValue());
    }
}
The attribute use a extension method for default value generation to any object:
public static object GetDefaultValue(this object obj)
{
      var objType = obj.GetType();
      if (objType.IsValueType)
          return Activator.CreateInstance(objType);
     return null;
}
And all this is used like this:
[JsonConverter(typeof(JsonConverterDefaultGuid))]
[NotDefault(ValidationMessages.FieldInvalid)]
public Guid SectionId { get; set; }
