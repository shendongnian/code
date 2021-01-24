public class HomeController : Controller
{
    private readonly IApiService _apiService;
    public HomeController(
        IApiService apiService)
    {
        _apiService = apiService;
    }
    public IActionResult Index()
    {
        // Get the data from the API into the ViewData
        // In this example, Id will be the Id of the dropdown option,
        // and the Name will be what's displayed to the user
        ViewData["DataFromArticle1"] = new SelectList(
                await _apiService.GetDataFromArticle1Async(), 
                "Id", "Name");
        ViewData["DataFromArticle2"] = new SelectList(
                await _apiService.GetDataFromArticle2Async(), 
                "Id", "Name");
        return View();
    }
}
Now, to populate the dropdowns in your View:
<select asp-items="ViewBag.DataFromArticle1"></select>
<select asp-items="ViewBag.DataFromArticle2"></select>
 
