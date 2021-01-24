namespace WorkProject
{
  [Route("A/Route")]
  public class WorkController : Controller
  {
    [HttpPost("DoStuff")]
    [Authorize(Policy = "CanDoStuff")]
    public IActionResult DoStuff(){/* */}
  }
}
Test.cs
namespace YourApplication.Tests
{
    public class Tests
        : IClassFixture<CustomWebApplicationFactory<YourApplication.Startup>>
    {
        private readonly CustomWebApplicationFactory<YourApplication.Startup> _factory;
        public Tests(CustomWebApplicationFactory<YourApplication.Startup> factory)
        {
            _factory = factory;
        }
        [Fact]
        public async Task SomeTest()
        {
            var client = _factory.CreateClient();
            var response = await client.PostAsync("/YourEndpoint");
            response.EnsureSuccessStatusCode();
            Assert.Equal(/* whatever your condition is */);
        }
    }
}
CustomWebApplicationFactory.cs
namespace WorkApp.Tests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup: class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);
            builder.ConfigureServices(services =>
            {
                services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "Test Scheme"; // has to match scheme in TestAuthenticationExtensions
                    options.DefaultChallengeScheme = "Test Scheme";
                }).AddTestAuth(o => { });
                
                services.AddAuthorization(options =>
                {
                    options.AddPolicy("CanDoStuff", policy =>
                        policy.Requirements.Add(new CanDoStuffRequirement()));
                });
             services.AddMvc().AddApplicationPart(typeof(YourApplication.Controllers.YourController).Assembly);
             services.AddTransient<IAuthorizationHandler, CanDoStuffActionHandler>();
            });
            builder.UseStartup<TestStartup>();
        }
    }
    internal class CanDoStuffActionHandler : AuthorizationHandler<CanDoStuffActionRequirement>
    {
        public CanDoStuffActionHandler()
        {
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CanDoStuffActionRequirement requirement)
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
    internal class CanDoStuffRequirement : IAuthorizationRequirement
    {
    }
}
TestStartup.cs
namespace YourApplication.Tests
{
    public class TestStartup : YourApplication.Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
        {
        }
        protected override void ConfigureAuthServices(IServiceCollection services)
        {
        }
    }
}
  [1]: https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-2.2
  [2]: https://medium.com/@jackwild/bypassing-asp-net-core-2-0-authorize-tags-in-integration-tests-7bda8fcb0eca
