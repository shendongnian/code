    public class DecryptRequestContent : System.Web.Http.AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var requestContent = actionContext.Request.Content;
            var newContent = Decryption (requestContent);
            actionContext.Request.Content = newContent;
        }
    }
