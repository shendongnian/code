    public static class Extension
    	{
    
    		public static T NullOrPropertyOf<T>(this XAttribute attribute, Func<string, T> converter)
    		{
    			if (attribute == null)
    			{
    				return default(T);
    			}
    			return converter.Invoke(attribute.Value);
    		}
    	}
    class Program
    {
        static void Main(string[] args)
        {
   
            Func<string, DateTime?> convertDT = (string str) =>
            {
                DateTime datetime;
                if (DateTime.TryParse(str, out datetime))
                {
                    return datetime;
                }
                return null;
            };
            Func<string, string> convertStr = (string str) =>
            {
                return str;
            };
            XAttribute x = null;
            Console.WriteLine(x.NullOrPropertyOf<string>(convertStr));
            Console.WriteLine(x.NullOrPropertyOf<DateTime?>(convertDT));
            XName t = "testing";
            x = new XAttribute(t, "test");
            Console.WriteLine(x.NullOrPropertyOf<string>(convertStr));
            x = new XAttribute(t, DateTime.Now);
            Console.WriteLine(x.NullOrPropertyOf<DateTime?>(convertDT));
        }
    }
