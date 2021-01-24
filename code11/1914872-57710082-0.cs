c#
public class AboutModel : PageModel
{
    public string Message { get; set; }
    protected HttpContext HttpContext => _httpContextAccessor.HttpContext;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public AboutModel(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public void OnGet()
    {
        Message = HttpContext.Request.PathBase;
    }
}
