    [JsonObject(MemberSerialization.OptIn)]
    public class RecognitionConfiguration {
        [JsonProperty(PropertyName = "PostProcessing", Required = Required.Always)]
        public PostRecognitionConfiguration PostProcessing{ get; set; }
    
        [JsonProperty(PropertyName = "Processing", Required = Required.Always)]
        public ProcessRecognitionConfiguration Processing{ get; set; }
    }
    
    [JsonObject(MemberSerialization.OptIn)]
    public class PostRecognitionConfiguration {
        [JsonProperty(Required = Required.Always)]
        public ValidationHandlerConfiguration ValidationHandlerConfiguration { get; set; }
    
        [JsonProperty] 
        public List<string> MatchingCharacterRemovals { get; set; }
    }
    
    [JsonObject(MemberSerialization.OptIn)]
    public class ProcessRecognitionConfiguration {
        [JsonProperty(PropertyName = "OrderSelection", Required = Required.Always)]
        public OrderSelectionConfiguration OrderSelection { get; set; }
    }
    public partial class ValidationHandlerConfiguration {
        [JsonProperty("MinimumTrustLevel")]
        public long MinimumTrustLevel { get; set; }
        [JsonProperty("MinimumMatchingTrustLevel")]
        public long MinimumMatchingTrustLevel { get; set; }
    }
    public partial class OrderSelectionConfiguration {
        [JsonProperty("SelectionDaysInterval")]
        public long SelectionDaysInterval { get; set; }
        [JsonProperty("SelectionDaysMaximum")]
        public long SelectionDaysMaximum { get; set; }
    }
