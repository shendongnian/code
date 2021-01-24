    using System;
    using Newtonsoft.Json;
    using System.Text;
    using System.IO;
    					
    public class Program
    {
    	public static void Main()
    	{
    		 var data = new
            {
                email = "data@ada.com",
                first_name = "abc",
    			last_name = "abc",
    			id = 1
            };
    		
    		var data1 = new {data};
            var s = new JsonSerializer();
            var sb = new StringBuilder();
            using (var w = new StringWriter(sb))
            {
                s.Serialize(w, data1);
            }
            Console.WriteLine(sb.ToString());
    	}
    }
