c#
public class RootObject
{
    [JsonProperty("msg")]
    public Message Message { get; set; }
}
public class Message
{
    [JsonProperty("interactive_link")]
    public string InteractiveLink { get; set; }
}
And finally do this:
c#
var inputObj = JsonConvert.DeserializeObject<RootObject>(data);
var message = inputObj.Message.InteractiveLink;
MessageBox.Show(message);
Hope this helps. 
