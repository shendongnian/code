{"status":"1","message":"OK","result":{"status":"0"}}
To Deserialize the above json properly, you will need to use the following two classes.
public class Result
{
    [JsonProperty("status")]
    public string Status { get; set; }
}
public class RootObject
{
    [JsonProperty("status")]
    public string Status { get; set; }
    [JsonProperty("message")]
    public string Message { get; set; }
    [JsonProperty("result")]
    public Result Result { get; set; }
}
Deserialize the json to `RootObject` and get the `result.status`.
 var jsonObj = JsonConvert.DeserializeObject<RootObject>(json);
 string status = jsonObj.Result.Status; // status will be 0.
