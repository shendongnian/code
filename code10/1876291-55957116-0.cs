    using System;
    using Newtonsoft.Json;
    
    namespace ConsoleApp11
    {
    	class Program
    	{
    		public class Message
    		{
    			public Enteries enteries { get; set; }
    		}
    		public class Enteries
    		{
    			public Content content { get; set; }
    		}
    		public class Content
    		{
    			public Properties properties { get; set; }
    		}
    		public class Properties
    		{
    			public string object_name { get; set; }
    		}
    
    		static void Main(string[] args)
    		{
    			var input = "{\"enteries\":{\"content\":{ \"properties\":{ \"object_name\":\"your value string\"}}}}";
    			Message msg = JsonConvert.DeserializeObject<Message>(input);
    			Console.WriteLine(msg?.enteries?.content?.properties?.object_name ?? "no value");
    			Console.ReadKey();
    		}
    	}
    }
