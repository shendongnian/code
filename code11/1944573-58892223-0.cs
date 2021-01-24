Dictionary<string, List<MessageItem>> messageItems = JsonConvert.DeserializeObject<Dictionary<string, List<MessageItem>>>(yourJson);
foreach(MessageItem item in messageItems["messages"])
{
	Console.WriteLine(item.Title);
}
OR you could write a wrapper class:
[JsonObject(MemberSerialization.OptIn)]
public class MessageItems
{
	[JsonProperty("messages")]
	public List<MessageItem> Messages { get; set; }
}
and deserialize to that
MessageItems messageItems = JsonConvert.DeserializeObject<MessageItems>(yourJson);
foreach(MessageItem item in messageItems.Messages)
{
	Console.WriteLine(item.Title);
}
To get those examples to work I had to remove the [JsonConverter(typeof (JsonDictionaryAttribute))] attributes from your MessageItem class and replace with [JsonProperty].
