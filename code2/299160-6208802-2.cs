        [ServiceContract]
        [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
        public class BlogService {
             [OperationContract]
             [WebGet(ResponseFormat = WebMessageFormat.Json)]
             public List<Article> GetBlogArticles()
             {
                 return Article.GetDummyArticles.ToList();
             }
        }
