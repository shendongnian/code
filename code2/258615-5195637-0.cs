    class Program
    	{
    		static void Main(string[] args)
    		{
    			RefFactory factory = new RefFactory();
    			ICommonFunctionality a = factory.Create(0);
    			Console.WriteLine(a.SomeMethod());
    
    			ICommonFunctionality b = factory.Create(1);
    			Console.WriteLine(b.SomeMethod());
    
    			ICommonFunctionality c = factory.Create(2);
    			Console.WriteLine(c.SomeMethod());
    
    			//The above is to just test. Should be something like this:
    			ICommonFunctionality Ref;
    
    			if (1 == 1)
    			{
    				Ref = factory.Create(0);
    			}
    			if (1 == 2)
    			{
    				Ref = factory.Create(1);
    			}
    
    			//etc..
    
    			Console.Read();
    		}
    	}
    
    	public class RefFactory
    	{
    		public ICommonFunctionality Create(int someCondition)
    		{
    			if (someCondition == 0)
    			{
    				return new RefA();
    			}
    			else if (someCondition == 1)
    			{
    				return new RefB();
    			}
    			else
    			{
    				return new RefC();
    			}
    		}
    	}
    
    	public interface ICommonFunctionality
    	{
    		bool SomeProperty { get; set; }
    		string SomeMethod();
    	}
    
    	public class RefA : ICommonFunctionality
    	{
    		public bool SomeProperty { get; set; }
    		public string SomeMethod()
    		{
    			return "RefA";
    		}
    	}
    
    	public class RefB : ICommonFunctionality
    	{
    		public bool SomeProperty { get; set; }
    		public string SomeMethod()
    		{
    			return "RefB";
    		}
    	}
    
    	public class RefC : ICommonFunctionality
    	{
    		public bool SomeProperty { get; set; }
    		public string SomeMethod()
    		{
    			return "RefC";
    		}
    	}
