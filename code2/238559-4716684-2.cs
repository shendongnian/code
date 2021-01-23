    class Book
    {
        public string Version { get; set; }
        public string Type { get; set; }
        public List<Chapter> Chapters { get; set; }
    }
    class Chapter
    {
        public int Number { get; set; }
        public string Title { get; set; }
    }
