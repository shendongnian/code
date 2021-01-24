csharp
public class Startup
{
	public Startup(IConfiguration configuration)
	{
		Configuration = configuration;
	}
	public IConfiguration Configuration { get; }
	public void ConfigureServices(IServiceCollection services)
	{
		services.AddSwaggerGen(options =>
		{
			options.SwaggerDoc("v1", new Info {Title = "C# Web API", Version = "v1"});
			var assemblyXmlPath = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
			var xmlPath = Path.Combine(AppContext.BaseDirectory, assemblyXmlPath);
			options.IncludeXmlComments(xmlPath);
		});
		   
		services.AddMvc()
			.SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
			.AddXmlSerializerFormatters(); // <= this was missing...
	}
	public void Configure(IApplicationBuilder app, IHostingEnvironment env)
	{
		if (env.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
		}
		else
		{
			app.UseHsts();
		}
		app.UseSwagger()
		   .UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
		app.UseHttpsRedirection();
		app.UseMvc();
	}
}
Now everything is on par for both endpoints:
powershell
λ  Invoke-WebRequest -Uri "https://localhost:5001/api/v1/values/json" -Headers @{'Accept' = 'application/json'; }
Invoke-WebRequest : The remote server returned an error: (422) Unprocessable Entity.
At line:1 char:1
+ Invoke-WebRequest -Uri "https://localhost:5001/api/v1/values/json" -H ...
+ ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    + CategoryInfo          : InvalidOperation: (System.Net.HttpWebRequest:HttpWebRequest) [Invoke-WebRequest], W
   ebException
    + FullyQualifiedErrorId : WebCmdletWebResponseException,Microsoft.PowerShell.Commands.InvokeWebRequestCommand
powershell
λ  Invoke-WebRequest -Uri "https://localhost:5001/api/v1/values/xml" -Headers @{'Accept' = 'application/xml'; }
Invoke-WebRequest : The remote server returned an error: (422) Unprocessable Entity.
At line:1 char:1
+ Invoke-WebRequest -Uri "https://localhost:5001/api/v1/values/xml" -He ...
+ ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    + CategoryInfo          : InvalidOperation: (System.Net.HttpWebRequest:HttpWebRequest) [Invoke-WebRequest], W
   ebException
    + FullyQualifiedErrorId : WebCmdletWebResponseException,Microsoft.PowerShell.Commands.InvokeWebRequestCommand
I think the error is kinda misleading or confusing it makes you think that the issue comes from the controller / action configuration instead of services configuration.
