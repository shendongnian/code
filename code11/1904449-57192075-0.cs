    public class AwbTrackingResponse
    {
        ...
        [JsonExtensionData]
        private Dictionary<string, JToken> EventData { get; set; }
        [JsonIgnore]
        public Dictionary<int, AwbTrackingEvent> Events
        {
            get
            {
                return EventData?.ToDictionary(
                    kvp => Convert.ToInt32(kvp.Key), 
                    kvp => kvp.Value.ToObject<AwbTrackingEvent>()
                );
            }
            set
            {
                EventData = value?.ToDictionary(
                    kvp => kvp.Key.ToString(),
                    kvp => JToken.FromObject(kvp.Value)
                );
            }
        }
    }
