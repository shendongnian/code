JsonConverterAttribute
JsonExtensionDataAttribute
JsonIgnoreAttribute
JsonPropertyNameAttribute
Unfortunately even a custom converter won't work because null values skip calling Read and Write methods.
public class Radiokiller
{
   [JsonConverter(typeof(MyCustomNotNullConverter<string>))] 
   public string Name { get; set; }  
}
public class MyCustomNotNullConverter<T> : JsonConverter<T>
{
	public override bool CanConvert(Type typeToConvert) => true;
	public override T Read(...)
	{
		//Not called for nulls
	}
	public override void Write(...)
	{
		// Not called for nulls
	}
}
