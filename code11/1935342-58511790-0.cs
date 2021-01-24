C#
[JsonObject(Description = "user")]
public class User
{
    [JsonProperty(PropertyName = "user")]
    public Dictionary<string, UserProperties> UserPropererties { get; set; }
}
You could also just rename User.UserProperties to `User.user`, but I assume you'd rather have some control over the process. 
You could make that `Dictionary<int, UserProperties>`, too. Works for me. 
