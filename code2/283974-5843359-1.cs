    public class Post : Entity
    {
        public string Title { get; set; }
        public virtual User Owner { get; set; }
        public virtual List<Vote> Votes { get; set; }
    }
