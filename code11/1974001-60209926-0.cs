    using System;
    
    public class Program
    {
    	public static void Main() {
    	  VersionAssembly240 obj1 = new VersionAssembly240();
    	  VersionAssembly250 obj2 = new VersionAssembly250();
    	  VersionAssembly260 obj3 = new VersionAssembly260();
    	  ChooseRightInstance( null, obj2,  null ,  "v25" );
        }
    
        public static void ChooseRightInstance(VersionAssembly240 obj1, VersionAssembly250 obj2, VersionAssembly260 obj3, string version) 
        {
    	  IVersionAssembly obj; //declare the object outside the if, as an instance of the interface
    	  if (version == "v24")
    	  {
    		obj = obj1;
    	  }
    	  else if (version == "v25")
    	  {
    		obj = obj2;
    	  }
    	  else
    	  {
    		obj = obj3;
    	  }
    
    	  Console.WriteLine(obj.example()); //can call the example() method because the interface defines it
        } 
    }
    //interface which defines the methods which all the classes must implement    
    public interface IVersionAssembly
    {
    	string example();
    }
    //all the classes implement the interface, but within the methods they can use different concrete implementations
    public class VersionAssembly260 : IVersionAssembly
    {
    	public string example()
    	{
    		return "v26";
    	}
    }
    
    public class VersionAssembly250 : IVersionAssembly
    {
    	public string example()
    	{
    		return "v25";
    	}
    }
    
    public class VersionAssembly240 : IVersionAssembly
    {
    	public string example()
    	{
    		return "v24";
    	}
    }
    
