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
