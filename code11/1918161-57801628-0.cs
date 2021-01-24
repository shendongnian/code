    namespace InheritanceTest
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			Console.WriteLine($"Base: {new BaseClass().CheckType()}");
    			Console.WriteLine($"Child: {new ChildClass().CheckType()}");
    			Console.WriteLine($"Static in base with child argument: {BaseClass.CheckType(new ChildClass())}");
    			Console.ReadLine();
    		}
    	}
    
    	public class BaseClass
    	{
    		public string CheckType()
    		{
    			return this.GetType().ToString();
    		}
    
    		public static string CheckType(BaseClass instance)
    		{
    			return instance.GetType().ToString();
    		}
    	}
    
    	public class ChildClass : BaseClass
    	{
    	}
    }
