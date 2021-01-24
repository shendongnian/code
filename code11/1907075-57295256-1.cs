c#
public class RootObject
{
    [JsonProperty("message")]
    public string Message { get; set; }
    [JsonProperty("errors")]
    public Errors Errors { get; set; }
}
`Errors.cs`, containing the following properties:
c#
public class Errors
{
    [JsonProperty("name")]
    public string[] Name { get; set; }
    [JsonProperty("gender")]
    public string[] Gender { get; set; }
    [JsonProperty("date_of_birth")]
    public string[] DateOfBirth { get; set; }
}
And then you read the whole thing like this:
c#
var inputObj = JsonConvert.DeserializeObject<RootObject>(json);
Where `inputObj` will be of type `RootObject` and `json` is the JSON you are receiving.
If you have implemented this correctly, use it like this:
c#
var message = inputObj.Message;
var nameErrors = inputObj.Errors;
var firstNameError = inputObj.Errors.Name[0];
Here is a visual:
Showing the whole object, filled with the properties:
[![enter image description here][1]][1]
The "main" error:
[![enter image description here][2]][2]
If you have any questions feel free to ask. 
  [1]: https://i.stack.imgur.com/zU0Sg.png
  [2]: https://i.stack.imgur.com/GMf9w.png
