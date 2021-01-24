cs
public class SomeModel
{
	public int Id { get; set; }
	public string Name { get; set; }
	[JsonExtensionData]
	public Dictionary<string, JsonElement> ExtensionData { get; set; }
    [JsonIgnore]
	public string Data
	{
		get
		{
			return ExtensionData?["Info"].GetRawText();
		}
	}
}
Then you can add an additional property to get a string from this dictionary by `Info` key. In code above the `Data` property will contain the expected string
{
    "Additional": "Fields",
    "Are": "Inside"
}
For some reasons adding the property with the same name `Info` doesn't work, even with `JsonIgnore`. Have a look at [Handle overflow JSON](https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-how-to#handle-overflow-json) for details
