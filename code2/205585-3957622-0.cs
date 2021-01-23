    public class ArticleService
    {
        private ArticleEntities _ctx;
        public ArticleService()
        {
            _ctx = new ArticleEntities();
        }
        public IEnumerable<Article> GetLatestArticles(bool Authorised) 
        {            
            return _ctx.Articles.Where(x => x.IsApproved == Authorised).OrderBy(x => x.ArticleDate);
        }
        public IEnumerable<Article> GetArticlesByMember(int MemberId, bool Authorised)
        {           
            return _ctx.Articles.Where(x => x.MemberID == MemberId && x.IsApproved == Authorised).OrderBy(x => x.ArticleDate);
        }
        public void Dispose()
        {
            _ctx.Dispose();
            _ctx = null;
        }
    }
