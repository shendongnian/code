    public class Question
    {
        public int Id { get; set; }
    
        public string Title { get; set; }
        public string Content { get; set; }
     
        public User Author { get; set; }
        public User LastEditor { get; set; }
        public DateTime LastChange { get; set; }
        public IList<Tag> Tags { get; set; }
    }
