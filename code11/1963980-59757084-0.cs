csharp
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        string json = File.ReadAllText("test.json");
        Result result = Result.FromJson(json);
        Console.WriteLine(result.Status);
        Console.WriteLine(result.Values.Count);
        Console.WriteLine(result.Values[0].User.FirstName);
    }
}
public sealed class Result
{
    public string Status { get; }
    public IReadOnlyList<ResultValue> Values { get; }
    private Result(string status, IReadOnlyList<ResultValue> values) =>
        (Status, Values) = (status, values);
    public static Result FromJson(string json)
    {
        JObject parsed = JObject.Parse(json);
        string status = (string) parsed["status"];
        JArray array = (JArray) parsed["value"];
        var values = array.Select(ResultValue.FromJToken).ToList().AsReadOnly();
        return new Result(status, values);
    }
}
public sealed class ResultValue
{
    public DateTime Timestamp { get; }
    public string Id { get; }
    public string Email { get; }
    public User User { get; }
    private ResultValue(DateTime timestamp, string id, string email, User user) =>
        (Timestamp, Id, Email, User) = (timestamp, id, email, user);
    internal static ResultValue FromJToken(JToken token)
    {
        JArray array = (JArray) token;
        DateTime timestamp = (DateTime) array[0];
        string id = (string) array[1];
        string email = (string) array[2];
        User user = array[3].ToObject<User>();
        return new ResultValue(timestamp, id, email, user);
    }
}
// TODO: Make this immutable, or everything else immutable
public sealed class User
{
    [JsonProperty("role")]
    public string Role { get; set; }
    [JsonProperty("company")]
    public string Company { get; set; }
    [JsonProperty("first_name")]
    public string FirstName { get; set; }
    [JsonProperty("last_name")]
    public string LastName { get; set; }
    [JsonProperty("modification_date")]
    public DateTime ModificationDate { get; set; }
}
