 c#
public class MyController : Controller
{
    private readonly IHostingEnvironment _env;
    public MyController(IHostingEnvironment env)
    {
        _env = env;
    }
    public IActionResult Get()
    {
        string path = System.IO.Path.Combine(_env.ContentRootPath, "/myfile.csv");
        if (!System.IO.File.Exists(path))
            return NotFound();
            
        return new FileStreamResult(System.IO.File.OpenRead(path), "text/csv");
    }
}
