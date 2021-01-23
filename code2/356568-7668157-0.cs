    public class Settings 
    {
         public string SettingCommand1(string command) {...}
         ...
         public string SettingCommand30(string command) {...}
    }
    public class Environment 
    {
         public string EnvironmentCommand1(string command) {...}
         ...
         public string EnvironmentCommand30(string command) {...}
    }
    public class Output
    {
         public string OutputCommand1(string command) {...}
         ...
         public string OutputCommand30(string command) {...}
    }    
    public static class CircuitLib
    {
         public static Settings Settings = new Settings ();
         public static Environment Environment = new Environment ();
         public static Output Output  = new Output();
    }
