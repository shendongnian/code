    public class Article
    {
        public int Id { get; set; }
        public int ArticleIndex { get; set; }
        public int Category { get; set; }
        public Guid User { get; set; }
        public int Parent { get; set; }
        public int Level { get; set; }
        public int Order { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateExpires { get; set; }
        public bool Show { get; set; }   
        public string Title { get; set; }
        public string TitleHtml { get; set; }
        public string Content { get; set; }
        public string ContentHtml { get; set; }
        public string ShortTitle { get; set; }
        public int ArticleCategoryId { get; set; }
        public virtual ArticleCategory ArticleCategory { get; set; }
    }
    
    public class ArticleCategory
    {
        public int Id { get; set; }
        public int CategoryIndex { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
