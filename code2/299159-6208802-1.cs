        public class Article    {
   
             public string Title { get; set; }
             public string Body { get; set; }
             public static IEnumerable<Article> GetDummyArticles() {
                 yield return new Article { Title = "Article 1", Body = "sdlkfjsdlkfjskl" };
                 yield return new Article { Title = "Article 2", Body = "sfsfsdfd23434wfdfsfdfkfjskl" };
             }
          }
   
