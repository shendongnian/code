    public class AccountMvcHandler : MvcHandler
    {
        public AccountModel Account { get; set; }
        public AccountMvcHandler(RequestContext requestContext)
            : base(requestContext)
        {
        }
        protected override IAsyncResult BeginProcessRequest(HttpContextBase httpContext, AsyncCallback callback, object state)
        {
            string accountName = this.RequestContext.RouteData.GetRequiredString("account");
            Account = ServiceFactory.GetService<IAccountService>().GetAccount(accountName);
            // URL doesn't contain valid account name - redirect to login page with Account Name textbox
            if (Account == null)
                httpContext.Response.Redirect(FormsAuthentication.LoginUrl);
            return base.BeginProcessRequest(httpContext, callback, state);
        }
    }
