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
If you have a specific pattern of settings, you can create a custom settings binder for your own "convention", i have provided a very basic sample, which handles the '.' in the settings.
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
			services.AddSingleton<IConfiguration>(configuration);
			services.ConfigureOptions<CustomConfigureOptions>();
			var container = services.BuildServiceProvider();
			using (var scope = container.CreateScope())
			{
				var appSettings = scope.ServiceProvider.GetRequiredService<IOptions<AppSettings>>();
				Console.WriteLine(appSettings);
			}
		}
	}
}
public class AppSettings
{
	public int NumberOfRetries { get; set; }
}
public class CustomConfigureOptions : IConfigureOptions<AppSettings>
{
	private readonly IConfiguration configuration; 
	
	public CustomConfigureOptions(IConfiguration configuration)
	{
		this.configuration = configuration;
	}
	
	public void Configure(AppSettings options)
	{
		foreach(var pair in configuration.AsEnumerable())
		{
			foreach(var property in typeof(AppSettings).GetProperties())
			{
				if (property.Name.Equals(pair.Key.Replace(".", "")))
				{
					property.SetValue(options, configuration.GetValue(property.PropertyType, pair.Key));
				}
			}
		}
	}
}
