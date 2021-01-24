c#
[Route("test")]
public class TestController :Controller
{
    [HttpGet("somepath/{a},{b},{c}")]
    public IActionResult Test(string a, string b, int c)
    {
        return Ok($"a: {a}, b: {b}, c: {c}");
    }
}
StartUp.cs:
c#
public class Startup
{
	public void ConfigureServices(IServiceCollection services)
	{
		services.AddMvc();
	}
	public void Configure(IApplicationBuilder app, IHostingEnvironment env)
	{
		app.UseMvc();
	}
}
Program.cs:
c#
public class Program
{
	public static void Main(string[] args)
	{
		CreateWebHostBuilder(args).Build().Run();
	}
	public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
		WebHost.CreateDefaultBuilder(args)
			.UseStartup<Startup>();
}
When opening `http://localhost:5000/test/somepath/abc,def,123` I get the expected output:
a: abc, b: def, c: 123
