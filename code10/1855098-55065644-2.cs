     public static class Extensions
        {
        	//create other overloads
        	public static void MyCheckMethodDate<TObj>(this TObj obj,Expression<Func<TObj,DateTime>> property, string value)
        	{
        		obj.MyCheckMethod(property, value, DateTime.Parse);
        	}
        	
        	public static void MyCheckMethod<TObj,TProp>(this TObj obj,Expression<Func<TObj,TProp>> property, string value,Func<string, TProp> converter)
            {
        		if(string.IsNullOrEmpty(value))
        			return;
        		
                var propertyInfo = ((MemberExpression)property.Body).Member as PropertyInfo;
        
                if(null != propertyInfo && propertyInfo.CanWrite)
                {
                  propertyInfo.SetValue(obj, converter(value));
                }
            }
        }
        
        public class Obj
        {
        	public object Prop1{get;set;}
        	public string Prop2{get;set;}
        	public DateTime Prop3{get;set;}
        }
        
        public class Program
        {
        	public static void Main()
        	{
        		var obj = new Obj();
        		
        		obj.MyCheckMethodDate(x=>x.Prop3, "2018-1-1");
        		
        		Console.WriteLine(obj.Prop3);
        	}
        }
