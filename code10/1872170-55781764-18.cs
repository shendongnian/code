    class Group
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public _Color color { get; set; }
    }
    
    class _Color
    {
        public int id { get; set; }
        public string hex { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
