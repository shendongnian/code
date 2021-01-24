json
{
    "token":"eyJraWQiOiJNSytSKzRhYUk4YjBxVkhBMkZLZFN4Ykdpb3RXbTNXOGhZWE45dXF3K3YwPSIsImFsZyI6IlJTMjU2In0.eyJzdWIiOiIxYmRlZjJkNy05YTRlLTRmYmYtYTk4Zi02Y2EwNzE0NTgzNzgiLCJlbWFpb"
}
you can 1: Deserialize it to a `dynamic` like so: (as mentioned in [this](https://stackoverflow.com/a/8972079/9363973) answer)
c#
dynamic parsed = JObject.Parse(authenticate.RawContent.ReadAsStringAsync().Result)
Console.WriteLine(parsed.token);
or (my preferred typesafe way) use a model class to deserialize to like so:
c#
class AuthenticationModel
{
    [JsonProperty("token")]
    public string Token {get; set;}
}
static async Task Main(string[] args)
{
    var parsed = JsonConvert.DeserializeObject<AuthenticationModel>(await authenticate.RawContent.ReadAsStringAsync());
    Console.WriteLine(parsed.Token);
}
