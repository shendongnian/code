"data:" {
  "mymsg":"h"
}
just correct your JSON. But I recommend using c# classes and serialization. Look at this simple example:
var payload = new {
    to = "XXXX",
    notification = new
    {
        body = "Test",
        title = "Test"
    },
    data = new {
      mymsg = "h"
    }
  }
// Using Newtonsoft.Json
string postbody = JsonConvert.SerializeObject(payload).ToString();
But its just example. You should create classes instead of anonym objects and using JsonProperty or another way to serialize the object. Something like that:
/// <summary>
/// Data for sending push-messages.
/// </summary>
public class PushData
{
  /// <summary>
  /// [IOS] Displaying message
  /// </summary>
  [JsonProperty("alert")]
  public Alert Alert { get; set; }
  /// <summary>
  /// [IOS] badge value (can accept string representaion of number or "Increment")
  /// </summary>
  [JsonProperty("badge")]
  public Int32? Badge { get; set; }
  /// <summary>
  /// [IOS] The name of sound to play
  /// </summary>
  [JsonProperty("sound")]
  public String Sound { get; set; }
  /// <summary>
  /// [IOS>=7] Content to download in background
  /// </summary>
  /// <remarks>
  /// Set 1 for silent mode
  /// </remarks>
  [JsonProperty("content-available")]
  public Int32? ContentAvailable { get; set; }
  /// <summary>
  /// [IOS>=8] Category of interactive push with additional actions
  /// </summary>
  [JsonProperty("category")]
  public String Category { get; set; }
  /// <summary>
  /// [Android] Used for collapsing some messages with same collapse_key
  /// </summary>
  [JsonProperty(PropertyName = "collapse_key")]
  public String CollapseKey { get; set; }
  /// <summary>
  /// [Android] This parameter specifies how long (in seconds) the message should be kept in GCM storage if the device is offline. 
  /// The maximum time to live supported is 4 weeks, and the default value is 4 weeks.
  /// </summary>
  /// <value>
  /// Time_to_live value of 0 means messages that can't be delivered immediately will be discarded
  /// </value>
  [JsonProperty("time_to_live")]
  public Int32 TimeToLive { get; set; }
  /// <summary>
  ///  [Android] Uri of activity to open when push activated by user
  /// </summary>
  [JsonProperty("url")]
  public String Url { get; set; }
  /// <summary>
  /// Payload for push
  /// </summary>
  [JsonProperty("data")]
  public Payload Payload { get; set; }
}
with message builder which serialize your message body to correct json string.
