    public class CustomResult : OkResult
    {
        private readonly string Reason;
    
        public CustomResult(string reason) : base()
        {
            Reason = reason;
        }
    
        public override void ExecuteResult(ActionContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
    
            context.HttpContext.Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = Reason;
            context.HttpContext.Response.StatusCode = StatusCode;
        }
    }
