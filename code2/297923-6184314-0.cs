    class Article
    {
        private EntitySet<CommentDto> _Comments;
        [Association(OtherKey = "ArticleID")]
        public virtual IList<CommentDto> Comments
        {
                get
                {
                    if (_Comments == null)
                        _Comments = new EntitySet<CommentDto>();
                    return _Comments;
                }
                set
                {
                    Comments.Assign(value);
                }
        }
    }
    class Comment
    {
        [Association(ThisKey="ArticleID")]
        public ArticleDto Article { get; set; }
    }
