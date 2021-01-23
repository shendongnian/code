    public class MyNavController : UINavigationController
    {
        Action<User> UserClickedAction;
        public MyNavController()
        {
            UserClickedAction = HandleUserClicked;
        }
    
        public void HandleUserClicked(User user)
        {
            ...
        }
    }
