    public class Post
    {
        public Post()
        {
          this.Url = new List<string>();
        }
        public int ID { get; set; }
        public string Text { get; set; }
        public List<string> Url { get; set; }
        public string Date { get; set; }
    }
