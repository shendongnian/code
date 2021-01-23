    static class Program
    {
        static void Main()
        {
            UserController userController = new UserController();
            Route route = new Route();
            route.InitRoute("pattern", new Route.Callback(userController.Action));
        }
    }
    public class Route
    {
        public delegate void Callback();
        public void InitRoute(string pattern, Callback c)
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
