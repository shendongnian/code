     > This class utilizes resources from pooled memory to minimize the impact of the garbage collector (GC) in high-usage scenarios. Failure to properly dispose this object will result in the memory not being returned to the pool, which will increase GC impact across various parts of the framework.
    An example of use is as follows:
		//https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#using-declarations 
		using var doc = JsonDocument.Parse(json);
		
		var names = doc.RootElement.EnumerateObject().Select(p => p.Name);
		Console.WriteLine("Property names: {0}", string.Join(",", names)); // Property names: status,message,Log_id,Log_status,FailureReason
		
		using var ms = new MemoryStream();
		using (var writer = new Utf8JsonWriter(ms, new JsonWriterOptions { Indented = true }))
		{
			doc.WriteTo(writer);
		}
		var json2 = Encoding.UTF8.GetString(ms.ToArray());
		Console.WriteLine(json2);
