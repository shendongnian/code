    public abstract class BasePost  // your former Posts class
    {
        public int ID { get; set; }
        public string UserName { get; set; }
    }
    public class Post : BasePost
    {
        public string Text { get; set; }
        // other properties of the Post class
    }
    public class Poll : BasePost
    {
        // properties of the Poll class
    }
