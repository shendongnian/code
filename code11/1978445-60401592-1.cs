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
Then you can add an additional property to get a string from this dictionary by `Info` key
