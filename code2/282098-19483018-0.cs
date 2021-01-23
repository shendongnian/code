    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ObjectInitializer
    {
    	public class Program
    	{
    		public enum Color { Red, Green, Blue, Yellow, Fidget } ;
    
    		public class Foo
    		{
    			public int FooId { get; set; }
    			public string FooName { get; set; }
    		}
    
    		public class Thing
    		{
    			public int ThingId { get; set; }
    			public string ThingName { get; set; }
    			public List<Foo> Foos { get; set; }
    		}
    
    		public class Widget
    		{
    			public long Sort { get; set; }
    			public char FirstLetter { get; set; }
    		}
    
    		public class TestMe
    		{
    			public Color Color { get; set; }
    			public long Key { get; set; }
    			public string Name { get; set; }
    			public DateTime Created { get; set; }
    			public DateTime? NCreated { get; set; }
    			public bool Deleted { get; set; }
    			public bool? NDeleted { get; set; }
    			public double Amount { get; set; }
    			public Thing MyThing { get; set; }
    			public List<Thing> Things { get; set; }
    			public List<Widget> Widgets { get; set; }
    		}
    
    		static void Main(string[] args)
    		{
    			var testMe = new TestMe
    			{
    				Color = Program.Color.Blue,
    				Key = 3,
    				Name = "SAK",
    				Created = new DateTime(2013,10,20,8,0,0),
    				NCreated = (DateTime?)null,
    				Deleted = false,
    				NDeleted = null,
    				Amount = 13.1313,
    				MyThing = new Thing(){ThingId=1,ThingName="Thing 1"},
    				Things = new List<Thing>
    				{
    					new Thing
    					{
    						ThingId=4,
    						ThingName="Thing 4",
    						Foos = new List<Foo>
    						{
    							new Foo{FooId=1, FooName="Foo 1"},
    							new Foo{FooId=2,FooName="Foo2"}
    						}
    					},
    					new Thing
    					{
    						ThingId=5,
    						ThingName="Thing 5",
    						Foos = new List<Foo>()
    					}
    				},
    				Widgets = new List<Widget>()
    			};
    
    			var objectInitializer = ToObjectInitializer(testMe);
    			Console.WriteLine(objectInitializer);
    
    			// This is the returned C# Object Initializer
    			var x = new TestMe { Color = Program.Color.Blue, Key = 3, Name = "SAK", Created = new DateTime(2013, 10, 20, 8, 0, 0), NCreated = null, Deleted = false, NDeleted = null, Amount = 13.1313, MyThing = new Thing { ThingId = 1, ThingName = "Thing 1", Foos = new List<Foo>() }, Things = new List<Thing> { new Thing { ThingId = 4, ThingName = "Thing 4", Foos = new List<Foo> { new Foo { FooId = 1, FooName = "Foo 1" }, new Foo { FooId = 2, FooName = "Foo2" } } }, new Thing { ThingId = 5, ThingName = "Thing 5", Foos = new List<Foo>() } }, Widgets = new List<Widget>() };
    			Console.WriteLine("");
    		}
    
    		public static string ToObjectInitializer(Object obj)
    		{
    			var sb = new StringBuilder(1024);
    
    			sb.Append("var x = ");
    			sb = WalkObject(obj, sb);
    			sb.Append(";");
    
    			return sb.ToString();
    		}
    
    		private static StringBuilder WalkObject(Object obj, StringBuilder sb)
    		{
    			var properties = obj.GetType().GetProperties();
    
    			var type = obj.GetType();
    			var typeName = type.Name;
    			sb.Append("new " + type.Name + " {");
    
    			bool appendComma = false;
    			DateTime workDt;
    			foreach (var property in properties)
    			{
    				if (appendComma) sb.Append(", ");
    				appendComma = true;
    
    				var pt = property.PropertyType;
    				var name = pt.Name;
    
    				var isList = property.PropertyType.GetInterfaces().Contains(typeof(IList));
    
    				var isClass = property.PropertyType.IsClass;
    
    				if (isList)
    				{
    					IList list = (IList)property.GetValue(obj, null);
    					var listTypeName = property.PropertyType.GetGenericArguments()[0].Name;
    
    					if (list != null && list.Count > 0)
    					{
    						sb.Append(property.Name + " = new List<" + listTypeName + ">{");
    						sb = WalkList( list, sb );
    						sb.Append("}");
    					}
    					else
    					{
    						sb.Append(property.Name + " = new List<" + listTypeName + ">()");
    					}
    				}
    				else if (property.PropertyType.IsEnum)
    				{
    					sb.AppendFormat("{0} = {1}", property.Name, property.GetValue(obj));
    				}
    				else
    				{
    					var value = property.GetValue(obj);
    					var isNullable = pt.IsGenericType && pt.GetGenericTypeDefinition() == typeof(Nullable<>);
    					if (isNullable)
    					{
    						name = pt.GetGenericArguments()[0].Name;
    						if (property.GetValue(obj) == null)
    						{
    							sb.AppendFormat("{0} = null", property.Name);
    							continue;
    						}
    					}
    
    					switch (name)
    					{
    						case "Int64":
    						case "Int32":
    						case "Int16":
    						case "Double":
    						case "Float":
    							sb.AppendFormat("{0} = {1}", property.Name, value);
    							break;
    						case "Boolean":
    							sb.AppendFormat("{0} = {1}", property.Name, Convert.ToBoolean(value) == true ? "true" : "false");
    							break;
    						case "DateTime":
    							workDt = Convert.ToDateTime(value);
    							sb.AppendFormat("{0} = new DateTime({1},{2},{3},{4},{5},{6})", property.Name, workDt.Year, workDt.Month, workDt.Day, workDt.Hour, workDt.Minute, workDt.Second);
    							break;
    						case "String":
    							sb.AppendFormat("{0} = \"{1}\"", property.Name, value);
    							break;
    						default:
    							// Handles all user classes, should likely have a better way
    							// to detect user class
    							sb.AppendFormat("{0} = ", property.Name);
    							WalkObject(property.GetValue(obj), sb);
    							break;
    					}
    				}
    			}
    
    			sb.Append("}");
    
    			return sb;
    		}
    
    		private static StringBuilder WalkList(IList list, StringBuilder sb)
    		{
    			bool appendComma = false;
    			foreach (object obj in list)
    			{
    				if (appendComma) sb.Append(", ");
    				appendComma = true;
    				WalkObject(obj, sb);
    			}
    
    			return sb;
    		}
    	}
    }
