    public class Review
    {
            public int ID { get; set; }
            public int Rating { get; set; }
            public string Body { get; set; }
            public string ReviewerName { get; set; }
            public int RestaurantID { get; set; }
            public DateTime Data { get; set; }
    
            public Restaurant Restaurant { get; set; }
    }
