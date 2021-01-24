public class CustomObject
{
    [JsonProperty("FirstName")]
    string fname { get; set; }
    [JsonProperty("LastName")]
    string lname { get; set; }
}
public void Test()
    {
        Dictionary<string, string> collection = new Dictionary<string, string>();
        collection.Add("FirstName", "Test");
        collection.Add("LastName", "1234");
        JObject jsobObj = JObject.Parse(JsonConvert.SerializeObject(collection, Newtonsoft.Json.Formatting.Indented));
        CustomObject custObj = new CustomObject();
        if (jsobObj != null)
        {
            if (jsobObj.Property("FirstName") != null && jsobObj.Property("LastName") != null)
            {
                custObj = jsobObj.ToObject<CustomObject>();
            }
        }
    }
