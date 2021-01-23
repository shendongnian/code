    static class Program
    {
        static void Main()
        {
            UserController userController = new UserController();
            Route route = new Route();
            route.InitRoute<UserController>("pattern", new Route.Callback<UserController>(userController.Action));
        }
    }
    public class Route
    {
        public delegate void Callback<T>();
        public void InitRoute<T>(string pattern, Callback<T> c)
        {
            c.Invoke();
        }
    }
    public class UserController
    {
        public void Action()
        {
            MessageBox.Show("hello world");
        }
    }
