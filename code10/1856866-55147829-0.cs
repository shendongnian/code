    public class IUserContext
    {
        public string  UserName 
        {
            get
            {
                return "user";
            }
        }
        public string Token 
        {
            get
            {
                return "token";
            }
        }
    }
    public class Program
    {
        public static IUserContext context = new IUserContext();
        
        public static void Main()
        {
            
            for(int i = 0; i < 4; i++) 
            {            
                Task.Factory.StartNew(() => method1());
            }
        }
        
        public static void method1()
        {
            Console.WriteLine("I'm task #" + Task.CurrentId + " and I work with user " + context.UserName + " that have token " + context.Token);
        }    
    }
