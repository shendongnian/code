    public class MyUserControl : UserControl 
    {
        [Dependency]
        public LoggedUserService UserService { get; set; }
    
        public void Method()
        {
            // the IoC container will ensure that the UserService
            // property has been set to an object
        }
    }
