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
For some reasons adding the property with the same name `Info` doesn't work, even with `JsonIgnore`. Have a look at [Handle overflow JSON](https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-how-to#handle-overflow-json) for details.
You can also declare the `Info` property as `JsonElement` type and get raw text from it
cs
public class SomeModel
{
	public int Id { get; set; }
	public string Name { get; set; }
	public JsonElement Info { get; set; }
}
cs
var model = JsonSerializer.Deserialize<SomeModel>(json);
var rawString = model.Info.GetRawText();
But it will cause a mixing of model representation and its serialization.
Another option is to parse the data using `JsonDocument`, enumerate properties and parse them one by one
cs
var document = JsonDocument.Parse(json);
foreach (var token in document.RootElement.EnumerateObject())
{
	if (token.Value.ValueKind == JsonValueKind.Number)
	{
		if(token.Value.TryGetInt32(out int number))
		{
		}
	}
	if (token.Value.ValueKind == JsonValueKind.String)
	{
		var stringValue = token.Value.GetString();
	}
	if(token.Value.ValueKind== JsonValueKind.Object)
	{
		var rawContent = token.Value.GetRawText();
	}
}
