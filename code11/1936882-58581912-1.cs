    public class Review 
    {
        public int Id {get;set;}
        public List<Genre> Genres { get; set; } = new List<Genre>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
