    using System.Configuration;		
    
        public class Program
        {
        	public static void Main()
        	{
        		string configvalue1 = ConfigurationManager.AppSettings["variable1Name"];
                //returns the value of "/mypathgoeshere/example"
        	}
        }
