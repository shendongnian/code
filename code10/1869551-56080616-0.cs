csharp
public class AdaptiveImageWithLongUrl : AdaptiveImage
{
    [JsonProperty(PropertyName = "url", Required = Required.Always)]
    public string LongUrl { get; set; }
}
**Then**, use your new image class and the new property when assigning long urls!
csharp
// A data URL that's longer than .NET max length
string actualUrl = "data:image/gif;base64," + string.Join("", new int[120000].Select(i => "A")) + "end";
AdaptiveCard card = new AdaptiveCard("1.0")
{
    Body =
    {
        new AdaptiveImageWithLongUrl()
        {
            LongUrl = actualUrl
        }
    }
};
// Place the JObject in the attachment!
var attachment = new Attachment()
{
    Content = card,
    ContentType = "application/vnd.microsoft.card.adaptive",
    Name = "cardName"
};
