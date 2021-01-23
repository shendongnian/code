    using System;
    using System.Reflection;
    
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			Type[] _types = null;
    
    			//load up a dll that you would like to introspect. In this example
    			//we are loading the currently executing assemble since all the sample code
    			//is constained within this simple program.  In practice you may want to change 
    			//this to a string that point to a particual assemble on your file system using 
    			//Assembly.LoadFrom("some assembly")
    			Assembly a = Assembly.GetExecutingAssembly();
    
    			//get an arrray of the types contained in the dll
    			_types = a.GetTypes();
    
    			//loop through the type contained in the assembly looking for 
    			//particuar types.
    			foreach (Type t in _types)
    			{
    				//see if this type does not contain the desired interfaec
    				//move to the next one.
    				if (t.GetInterface("CustomInterface") == null)
    				{
    					continue;
    				}
    
    				//get a reference to the attribute
    				object[] attributes = t.GetCustomAttributes(typeof(CustomAttribute), false);
    				CustomAttribute attribute = (CustomAttribute)attributes[0];
    
    				//do something with the attribue 
    				Console.WriteLine(attribute.Name);
    			}
    		}
    	}
    
    
    	/// <summary>
    	/// This is a sample custom attribute class.  Add addtional properties as needed!
    	/// </summary>
    	public class CustomAttribute : Attribute
    	{
    		private string _name = string.Empty;
    
    		public CustomAttribute(string name)
    			: base()
    		{
    			_name = name;
    		}
    
    		public string Name
    		{
    			get
    			{
    				return _name;
    			}
    			set
    			{
    				_name = value;
    			}
    		}
    	}
    
    	/// <summary>
    	/// Here is a custom interface that we can search for while using reflection.  
    	///  </summary>
    	public interface CustomInterface
    	{
    		void CustomMethod();
    	}
    
    	/// <summary>
    	/// Here is a sample class that implements our custom interface and custom attribute.
    	/// </summary>
    	[CustomAttribute("Some string I would like to assiciate with this class")]
    	public class TestClass : CustomInterface
    	{
    		public TestClass()
    		{
    		}
    
    		public void CustomMethod()
    		{
    			//do some work
    		}
    	}
    
    	/// <summary>
    	/// Just another class without the interface or attribute so you can see how to just 
    	/// target the class you would like by the interface.
    	/// </summary>
    	public class TestClass2
    	{
    		public TestClass2()
    		{
    		}
    
    		public void CustomMethod()
    		{
    			//do some work
    		}
    	}
    }
