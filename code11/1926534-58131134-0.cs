    using System;
    using System.Reflection;
    
    class TestClass
    {
    	public int publicIntField;
    	public string publicStringField;
    	public int publicIntProp {get; set;}
    	public string publicStringProp {get; set;}
    	public static int staticInt;
    }
    		
    public class Program
    {
    	public static void Main()
    	{
    		var src = new TestClass();
    		src.publicIntField = 7;
    		src.publicIntProp = 12;
    		src.publicStringField = "foo";
    		src.publicStringProp = "baz";
    		
    		var dest = new TestClass();
    		DoIt(src, dest);
    		DoItWithGenerics(src, dest);
    	}
    	
    	public static void  DoIt(object src, object dest)
    	{
    		Console.WriteLine("DoIt");
    		Type t = src.GetType();
    		// TODO  check the 2 objects have same type
    		
    		foreach (PropertyInfo  p in t.GetProperties(BindingFlags.Public|BindingFlags.Instance))
    		{
            	Console.WriteLine(p.Name);
    			p.SetValue(dest, p.GetValue(src));
    		}
    
    		foreach (FieldInfo  fi in t.GetFields(BindingFlags.Public|BindingFlags.Instance))
    		{
            	Console.WriteLine(fi.Name);
    			fi.SetValue(dest, fi.GetValue(src));
    		}
    		Console.WriteLine("*****");
    	}
    
    	public static void DoItWithGenerics<T>(T src, T dest) where T:class // only works for reference type if you pass both object and destination as parameter, modify if needed
    	{
    		Console.WriteLine("DoItWithGenerics");
    		
    		Type t = typeof(T);
            // no need for type check
    		
    		foreach (PropertyInfo  p in t.GetProperties(BindingFlags.Public|BindingFlags.Instance))
    		{
            	Console.WriteLine(p.Name);
    			p.SetValue(dest, p.GetValue(src));
    		}
    
    		foreach (FieldInfo  fi in t.GetFields(BindingFlags.Public|BindingFlags.Instance))
    		{
            	Console.WriteLine(fi.Name);
    			fi.SetValue(dest, fi.GetValue(src));
    		}
    		Console.WriteLine("*****");
    	}
    }
