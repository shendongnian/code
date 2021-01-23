    using System.Linq;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using System.IO;
    using System;
    
    namespace NS
    {
    	public class Data
    	{
    		public class Nested
    		{
    			public string The     { get; set; }
    			public string[] stuff = {"lazy Cow Jumped Over", "The", "Moon"};
    		}
    
    		public List<Nested> Items;
    	}
    
    	static class Helper
    	{
    		public static string ToXml<T>(this T obj) where T:class, new()
    		{
    			if (null==obj) return null;
    
    			using (var mem = new MemoryStream())
    			{
    				var ser = new XmlSerializer(typeof(T));
    				ser.Serialize(mem, obj);
    				return System.Text.Encoding.UTF8.GetString(mem.ToArray());
    			}
    		}
    
    		public static T FromXml<T>(this string xml) where T: new()
    		{
    			using (var mem = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(xml)))
    			{
    				var ser = new XmlSerializer(typeof(T));
    				return (T) ser.Deserialize(mem);
    			}
    		}
    
    	}
    
    	class Program
    	{
    		public static void Main(string[] args)
    		{
    			var data = new Data { Items = new List<Data.Nested> { new Data.Nested {The="1"} } };
    			Console.WriteLine(data.ToXml());
    
    			var clone = data.ToXml().FromXml<Data>();
    			Console.WriteLine("Deserialized: {0}", !ReferenceEquals(data, clone));
    			Console.WriteLine("Identical: {0}", Equals(data.ToXml(), clone.ToXml()));
    		}
    	}
    }
    	
