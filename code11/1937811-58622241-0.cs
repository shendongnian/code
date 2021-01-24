    public class CheckRequest
    {
        [JsonProperty("app_ids")]
        [Required(ErrorMessage = "List of AppIds can not be empty")]
        public List<string> AppIds { get; set; }
    }
