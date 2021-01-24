    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    
    public class Program
    {
    	public static void Main(string[] args)
    	{
    		var dynamicObject = new
    		{
    			utcDate = DateTime.UtcNow, //This one has Kind = DateTimeKind.Utc
     			localDate = DateTime.Now //This one has Kind = DateTimeKind.Local
    		}
    
    		;
    		var isoDateTimeConverter = new IsoDateTimeConverter();
    		isoDateTimeConverter.DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ssK";
    		var serializerSettings = new JsonSerializerSettings();
    		serializerSettings.Converters.Add(isoDateTimeConverter);
    		var s = new System.Text.StringBuilder();
    		using (var w = new System.IO.StringWriter(s))
    		using (var writer = new JsonTextWriter(w)
    				   {Formatting = Formatting.Indented})
    		{
    			var serializer = JsonSerializer.Create(serializerSettings);
    			serializer.Serialize(writer, dynamicObject);
    			writer.Flush();
    		}
    
    		Console.WriteLine(s.ToString());
    	}
    }
