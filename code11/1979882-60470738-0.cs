c#
void Main()
{
	string json = @"{
	  ""Logging"": {	
		""LogLevel"": {
		""Default"": ""Information"",
	      ""Microsoft"": ""Warning"",
	      ""Microsoft.Hosting.Lifetime"": ""Information""
	
		}
	  },
	  ""AllowedHosts"": ""*"",
	  ""Number.Of.Retries"":  5
	}";
	using (var doc = System.Text.Json.JsonDocument.Parse(json, new JsonDocumentOptions {  AllowTrailingCommas = true, CommentHandling = JsonCommentHandling.Skip } ))
	{
		using(var stream = new MemoryStream())
		{
			using (var writer = new Utf8JsonWriter(stream))
			{
				doc.WriteTo(writer);
				writer.Flush();
			}		
			
			stream.Position = 0;
			
			// Usable code here
			IConfigurationRoot configuration = new ConfigurationBuilder().AddJsonStream(stream).Build();
			var services = new ServiceCollection();
			services.AddOptions<AppSettings>();
			// There is an option to configure it manually here, if it does not fit the convention
			services.Configure<AppSettings>((options) =>
			{
				options.NumberOfRetries = configuration.GetValue<int>("Number.Of.Retries");
			});
			var container = services.BuildServiceProvider();
			using (var scope = container.CreateScope())
			{
				var appSettings = scope.ServiceProvider.GetRequiredService<IOptions<AppSettings>>();
				Console.WriteLine(appSettings.Value.NumberOfRetries);
			}
		}
	}
}
public class AppSettings
{
	public int NumberOfRetries { get; set; }
}  
