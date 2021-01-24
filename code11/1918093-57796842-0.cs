    struct PriceAtTime
    {
        public DateTime Timestamp { get; set; }
        public float Price { get; set; } // Or whatever your float represents
    }
    
    List<PriceAtTime> myData = GetTheData(); // Assumes the provided data is ordered
                                             // by timestamp.
