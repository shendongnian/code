c#
class Program
{
    // this throws a NLogConfigurationException because of bad config. (like invalid XML)
    // as this issue will be throw before Main() is called, you will get
    // a TypeInitializationException instead of a NLogConfigurationException
    private static Logger logger = LogManager.GetCurrentClassLogger();
    
    static void Main()
    {
        Console.WriteLine("Press any key");
        Console.ReadLine();
    }
}
## Solutions
3 possible solutions:
### Using lazy
class Program
{
    private static Lazy<Logger> logger = new Lazy<Logger>(() => LogManager.GetCurrentClassLogger());
    static void Main()
    {
        Console.WriteLine("Press any key");
        Console.ReadLine();
    }
}
### Create the logger in the main()
c#
class Program
{
    private static Logger logger;
    static void Main()
    {
        logger = LogManager.GetCurrentClassLogger();
        Console.WriteLine("Press any key");
        Console.ReadLine();
    }
}
### Create a local logger
c#
class Program
{
    static void Main()
    {
        private logger = LogManager.GetCurrentClassLogger();
        Console.WriteLine("Press any key");
        Console.ReadLine();
    }
}
