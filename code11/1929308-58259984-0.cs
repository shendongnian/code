using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
namespace ASPNetCoreApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateWebHostBuilder(args).Build().Run();
		}   // Main
		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
			.ConfigureAppConfiguration((hostingContext, config) =>
			{
				var settings = config.Build();
				config.AddAzureAppConfiguration(options =>
				{
					// fetch connection string from local config. Could use KeyVault, or Secrets as well.
					options.Connect(settings["ConnectionStrings:AzureConfiguration"])
					// filter configs so we are only searching against configs that meet this pattern
					.Use(keyFilter: "WebApp:*")
					.ConfigureRefresh(refreshOptions =>
					{ 
						// When this value changes, on the next refresh operation, the config will update all modified configs since it was last refreshed.
						refreshOptions.Register("WebApp:Sentinel", true);
					    // Set a timeout for the cache so that it will poll the azure config every X timespan.
						refreshOptions.SetCacheExpiration(cacheExpirationTime: new System.TimeSpan(0, 0, 0, 15, 0));
					});
				});
			})
			.UseStartup<Startup>();
	}
}
Then in Startup.cs:
using ASPNetCoreApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace ASPNetCoreApp
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}
		public IConfiguration Configuration { get; }
		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
            // bind the config to our DI container for the settings we are pulling down from azure.
			services.Configure<Settings>(Configuration.GetSection("WebApp:Settings"));
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}
		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}
            // Set the Azure middleware to handle configuration
            // It will pull the config down without this, but will not refresh.
			app.UseAzureAppConfiguration();
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();
			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
The Settings model I am binding my azure retrieved data to:
namespace ASPNetCoreApp.Models
{
	public class Settings
	{
		public string BackgroundColor { get; set; }
		public long FontSize { get; set; }
		public string FontColor { get; set; }
		public string Message { get; set; }
	}
}
A generic home controller with the config being set to the ViewBag to pass in to our view:
using ASPNetCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
namespace ASPNetCoreApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly Settings _Settings;
		public HomeController(IOptionsSnapshot<Settings> settings)
		{
			_Settings = settings.Value;
		}
		public IActionResult Index()
		{
			ViewData["BackgroundColor"] = _Settings.BackgroundColor;
			ViewData["FontSize"] = _Settings.FontSize;
			ViewData["FontColor"] = _Settings.FontColor;
			ViewData["Message"] = _Settings.Message;
			return View();
		}
		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";
			return View();
		}
		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";
			return View();
		}
		public IActionResult Privacy()
		{
			return View();
		}
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
Our View:
<!DOCTYPE html>
<html lang="en">
<style>
    body {
        background-color: @ViewData["BackgroundColor"]
    }
    h1 {
        color: @ViewData["FontColor"];
        font-size: @ViewData["FontSize"];
    }
</style>
<head>
	<title>Index View</title>
</head>
<body>
	<h1>@ViewData["Message"]</h1>
</body>
</html>
Hope this helps someone else!
