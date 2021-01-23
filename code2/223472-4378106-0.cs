    public class BlogViewModel
    {
        public int ID { get; set; }
        public sring Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string PostedBy { get; set; }
        public string Body { get; set; }
        public IEnumerable<TagViewMOdel> Tags { get; set; }
    }
    public class TagViewModel
    {
        public string Tag { get; set; }
        public int ID { get; set; }
    }
