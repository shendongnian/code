    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication107
    {
        class Program
        {
            static void Main(string[] args)
            {
                Context _context = new Context();
                string ArticleNo = "1234";
                var results = (from a in _context.article.Where(x => x.Id == ArticleNo)
                               join ab in _context.reference
                                  .Where(x => (x.ArticleFromId == x.ArticleToId))
                                  on a.Id equals ab.ArticleFromId
                               select new { a = a, ab = ab }
                              ).Select(r => new Reference()
                              {
                                  ArticleFromNavigation = r.a,
                                  ArticleToNavigation = r.a.ReferenceArticleToNavigations.ToList() 
                              }).ToList();
            }
        }
        public class Context
        {
            public List<Reference> reference { get; set; }
            public List<Article> article { get; set; }
        }
        public class Reference
        {
            public string ArticleFromId { get; set; }
            public string ArticleToId { get; set; }
            public Article ArticleFromNavigation { get; set; }
            public List<string> ArticleToNavigation { get; set; }
        }
        public class Article
        {
            public string Id { get; set; }
            public List<string> ReferenceArticleToNavigations { get; set; }
        }
    }
