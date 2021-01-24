    public class StudentViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [JsonProperty("location")]
        [JsonConverter(typeof(CustomLocationConverter))]
        public ILocation Address { get; set; }
    }
