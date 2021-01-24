     public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string ArticleText { get; set; }
        public List<Comment> Comments { get; set; }
    }
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public int ArticleId { get; set; }
    }
    //Controller 
    public async Task<IActionResult> Index()
    {
        var ArticalsWithComents = await _context.Article.Include(a => a.Comment);
             return View(ArticalsWithComents.ToListAsync());
    }
   
    
