    using System;
    using System.Linq;
    using System.Xml.Linq;
    [AttributeUsage(AttributeTargets.Property)]
    class PropertyAttribute : Attribute { }
    
    class BaseClass
    {
    	[Property]
    	public int Id { get; set; }
    	
    	IEnumerable<XElement> PropertyValues {
    		get {
    			return from prop in GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
    		           where prop.GetGetMethod () != null
    			       let attr = prop.GetCustomAttributes(typeof(PropertyAttribute), false)
    			   	   	   	   	      .OfType<PropertyAttribute>()
    			   	   	   	          .SingleOrDefault()
    			       where attr != null
    			       let value = Convert.ToString (prop.GetValue(this, null))
    			       select new XElement ("field",
    				       new XAttribute ("name", prop.Name),
    					   new XAttribute ("value", value ?? "null")
    				   );
    		}
    	}
    	
    	public XElement ToXml ()
    	{
    		return new XElement ("class",
    			   new XAttribute ("name", GetType ().Name),
    			   PropertyValues
    			   );
    	}
    }
    
    class DerivedClass : BaseClass
    {
    	[Property]
    	public string Name { get; set; }
    }
    
    public static class Program
    {
        public static void Main()
        {
    		var instance = new DerivedClass { Id = 42, Name = "Johnny" };
    		Console.WriteLine (instance.ToXml ());
        }
    }
