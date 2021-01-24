    public class PassportTagHelper : TagHelper
    {
        private readonly IAuthorizationService authorizationService;
    
        public PassportTagHelper(IAuthorizationService authorizationService)
        {
            this.authorizationService = authorizationService;
        }
    
        [ViewContext]
        public ViewContext ViewContext { get; set; }
    
        public override async Task ProcessAsync(TagHelperContext ctx, TagHelperOutput output)
        {
            var httpContext = ViewContext.HttpContext;
            var authorizationResult = await authorizationService
                .AuthorizeAsync(httpContext.User, "UserHasRecentPassport");
    
            if (!authorizationResult.Succeeded)
                output.SuppressOutput();
            }
        }
    }
