    void Main()
    {
        var foo = new Bar.Foo();
        ILog logger = foo.GetLogger();
    }   
    
    public static class LogHelper
    {
        public static ILog GetLogger(this object o)
        {
            return LogManager.GetLogger(o.GetType());
        }
    }
    
    namespace Bar
    {
        public class Foo {}
    }
    
    // Faking log4net
    public class ILog {}
    public class LogManager
    {
        public static ILog GetLogger(Type type)
        {
            Console.WriteLine("Log: " + type.ToString());
            return null;
        }
    }
