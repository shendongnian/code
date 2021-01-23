    // Container I wanted to discard
    public class TrackProfileResponse
    {
        [JsonProperty("response")]
        public Response Response { get; set; }
    }
    
    // Code for discarding it
    var jObject = JObject.Parse(s);
    var jToken = jObject["response"];
    var response = jToken.ToObject<Response>();
            
