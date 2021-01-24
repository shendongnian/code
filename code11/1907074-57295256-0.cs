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
If you have any questions feel free to ask. 
