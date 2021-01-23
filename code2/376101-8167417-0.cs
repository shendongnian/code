    ControllerBuilder.Current.SetControllerFactory(new CustomControllerFactory())
    public class CustomControllerFactory : DefaultControllerFactory
    {
        private readonly IUserRepository userRepository;
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            return new BaseController(userRepository);
        }
    }
