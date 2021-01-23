    public class ArticleAuthorizeAttribute : AuthorizeAttribute
    {
        public enum ArticleAction
        { 
            Read,
            Create,
            Update,
            Delete
        }
        public ArticleAction Action { get; set; }
        public int ArticleID { get; set; }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            //do custom authorizization using Action and ArticleID properties
        }
    }
