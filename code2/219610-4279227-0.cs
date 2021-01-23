        public string ID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public List<string> Tags { get; set; }
        public DateTime DateCreated { get; set; }
        public string ForumID { get; set; }
        public List<Answers> Answers { get; set; }
    }
