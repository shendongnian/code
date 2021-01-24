    public class FrontPageItem
    {
        public int Id { get; set; }
        public int ItemType { get; set; } // 1 = Article, 2 = WebPage, etc...
   
        public Article Article { get; set; }
        public WebPage WebPage { get; set; }
    }
