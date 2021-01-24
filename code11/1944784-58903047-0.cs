    public class SaveRequest
        {
            [JsonProperty("category_id")]
            [Required(ErrorMessage = "You have to choise category!!!")]
            public int Category_ID { get; set; }
    
            [JsonProperty("title")]
            [Required(ErrorMessage = "You have to type title!!!")]
            public string Title { get; set; }
        } 
