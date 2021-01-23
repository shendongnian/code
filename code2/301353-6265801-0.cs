    public class MegaController
    {
        protected User CurrentUser { get; set; }
    
        protected override void Initialize(RequestContext context)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var userRepository = new UserRepository();
                CurrentUser = userRepository.GetUser(
                    requestContext.HttpContext.User.Identity.Name);
            }
        }
    }
