    public class Question
    {
        public int Id { get; set; }
        [UIHint("tags")]
        public ICollection<string> Tags { get; set; }
    }
