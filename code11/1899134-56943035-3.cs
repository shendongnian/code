public class LRController : Controller
{
    private readonly IAuthorizationService _authorization;
    // you're missing this constructor
    public LRController(IAuthorizationService authorization)
    {
        _authorization = authorization;
    }
    public async Task<RedirectToActionResult> Index()
    {
        var superAdmin = await _authorization.AuthorizeAsync(User, "IsLucky");
        //rest of your code here
    }
}
**EDIT**
Additionally, if you wanted/needed to inject other interfaces into this controller, you would add it to that LRController constructor. Would look something like this:
public class LRController : Controller
{
    private readonly IAuthorizationService _authorization;
    private readonly IOtherService _otherService;
    public LRController(IAuthorizationService authorization, IOtherService otherService)
    {
        _authorization = authorization;
        _otherService = otherService;
    }
    public async Task<RedirectToActionResult> Index()
    {
        var superAdmin = await _authorization.AuthorizeAsync(User, "IsLucky");
    }
    public async Task Foo()
    {
        await _otherService.Bar();
    }
}
