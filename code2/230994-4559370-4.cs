    static class Program
    {
        static void Main()
        {
            UserController userController = new UserController();
            Route route = new Route("pattern", new Route.Callback(userController.Action));
        }
    }
    public class Route
    {
        public delegate void Callback();
        public Route(string pattern, Callback c)
        {
            //if matches
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
