    [JsonObject(MemberSerialization.OptIn)]
    public class ModalOptions
    {
        [JsonProperty]
        public object href { get; set; }
        [JsonProperty]
        public object type { get; set; }
    }
