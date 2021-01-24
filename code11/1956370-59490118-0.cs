cs
public class MyMappingProfile : Profile
{
    public MyMappingProfile()
    {
        CreateMap<Dto, ViewModel>()
            .ForMember(x => x.MemberId, opt => opt.MapFrom<HttpContextValueResolver>());
    }
}
Then the value resolver:
cs
public class HttpContextValueResolver : IValueResolver<Dto, ViewModel, string>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public HttpContextValueResolver(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public string Resolve(Dto source, ViewModel destination, string destMember, ResolutionContext context)
    {
        // Obtain whatever you need from HTTP context.
        // Warning! HTTP context may be null.
        return _httpContextAccessor.HttpContext?.Request.Path;
    }
}
To acess HttpContext outside a controller I used a dedicated for that purpose service called `IHttpContextAccessor`. Read more about it in the [docs](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-context?view=aspnetcore-3.1).
It isn't automatically available, so I need to register it in `Startup` alongside with the AutoMapper:
cs
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllersWithViews();
    services.AddAutoMapper(typeof(Startup));
    services.AddHttpContextAccessor();
}
Take notice that registering AutoMapper while passing just one type (of Startup), requires that all mapping profiles need to be in the same assembly (project) as the Startup. With mapping profiles in more than one assembly, you need to specify those assemblies or types with a suitable overload of the `AddAutoMapper()` method.
And finally usage in an example controller:
cs
public class HomeController : Controller
{
    private readonly IMapper mapper;
    public HomeController(IMapper mapper)
    {
        this.mapper = mapper;
    }
    public IActionResult Index()
    {
        var source = new Dto
        {
            MemberID = "123",
        };
        var result = mapper.Map<ViewModel>(source);
        return View();
    }
}
And here are the dto and view model I used:
cs
public class Dto
{
    public string MemberID { get; set; }
}
cs
public class ViewModel
{
    public string MemberId { get; set; }
}
