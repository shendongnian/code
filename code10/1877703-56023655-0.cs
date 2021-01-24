    [JsonObject(Title="People")]
    public class Type
    {
    
       [JsonProperty("name")]
       string Name{ get; set; }
       [JsonProperty("fields")]
       Field FieldValue[]{ get; set; }
    }
