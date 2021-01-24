    [JsonConverter(typeof(ServiceResponceConverter))]
    public class ServiceResponce
    {
        public Event[] Events { get; set; }
    }
