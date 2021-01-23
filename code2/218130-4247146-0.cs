    // Common.dll
    
    public interface IPlatformInfo
    {
        string PlatformName { get; }
    }
    
    public interface PlatformFactory
    {
        IPlatformInfo CreatePlatformInfo();
        // other...
    }
    
    public class WelcomeMessage
    {
        private IPlatformInfo platformInfo;
    
        public WelcomeMessage(IPlatformInfo platformInfo)
        {
            this.platformInfo = platformInfo;
        }
    
        public string GetMessage()
        {
            return "Welcome at " + platformInfo.PlatformName + "!";
        }
    }
    
    // WindowsApp.exe
    
    public class WindowsPlatformInfo : IPlatformInfo
    {
        public string PlatformName
        {
            get { return "Windows"; }
        }
    }
    
    public class WindowsPlatformFactory : PlatformFactory
    {
        public IPlatformInfo CreatePlatformInfo()
        {
            return new WindowsPlatformInfo();
        }
    }
    
    public class WindowsProgram
    {
        public static void Main(string[] args)
        {
            var factory = new WindowsPlatformFactory();
            var message = new WelcomeMessage(factory.CreatePlatformInfo());
            Console.WriteLine(message.GetMessage());
        }
    }
    
    // MonoApp.exe
    
    public class MonoPlatformInfo : IPlatformInfo
    {
        public string PlatformName
        {
            get { return "Mono"; }
        }
    }
    
    public class MonoPlatformFactory : PlatformFactory
    {
        public IPlatformInfo CreatePlatformInfo()
        {
            return new MonoPlatformInfo();
        }
    }
    
    public class MonoProgram
    {
        public static void Main(string[] args)
        {
            var factory = new MonoPlatformFactory();
            var message = new WelcomeMessage(factory.CreatePlatformInfo());
            Console.WriteLine(message.GetMessage());
        }
    }
