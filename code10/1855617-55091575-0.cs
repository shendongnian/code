    public class AppActionNameAttribute : Attribute 
    { 
        public string Action { get; set; } 
        public AppActionNameAttribute(string action) { Action = action; } 
    }
    
    public interface IAppAction 
    {
        int Run(Dictionary<string,string> cmdLineArgs, SomeObject obj);
    }
    
    [AppActionName("update")]
    public class UpdateAction : IAppAction
    {
        public int Run(Dictionary<string,string> cmdLineArgs, SomeObject obj) 
        { 
            Console.WriteLine("Handled :)"); 
            return 1;
        }
    }
    
    public class SomeObject { }
