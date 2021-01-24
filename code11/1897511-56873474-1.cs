     public class SearchEventDto : IDto
        {
            [KendoColumn(Order = 1, DisplayName = "Timestamp", UIType = UIType.DateTime)]
            [PropertyName("@timestamp")]
            public DateTime timestamp { get; set; }
    
        }
