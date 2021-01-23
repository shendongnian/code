    public class Boss
    {
        public void Kick()
        {
            Console.WriteLine("Kick");
        }
        public void Talk(string message)
        {
            Console.WriteLine("Talk " + message);
        }
        public void Run()
        {
            Console.WriteLine("Run");
        }
    }
    
    class Program
    {
        static void AutoSwitch(object obj, string methodName, params object[] parameters)
        {
            var objType = typeof(obj);
            var method = objType.GetMethod(methodName);
            method.Invoke(obj, parameters);
        }
    
        static void Main(string[] args)
        {
            var obj = new Boss();
    
            AutoSwitch(obj, "Talk", "Hello World");
            AutoSwitch(obj, "Kick");
        }
    }
