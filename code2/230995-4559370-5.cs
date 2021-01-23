    static class Program
    {
        static void Main()
        {
            Route r = new Route("pattern", typeof(UserController), "Action");
        }
    }
    public class Route
    {
        public Route(string pattern, Type type, string methodName)
        {
            object objectToUse = Activator.CreateInstance(type, null);
            MethodInfo method = type.GetMethod(methodName);
            string[] args = new string[1];
            args[0] = "hello world";
            method.Invoke(objectToUse, args);
        }
    }
    public class UserController
    {
        public void Action(string message)
        {
            MessageBox.Show(message);
        }
    }
