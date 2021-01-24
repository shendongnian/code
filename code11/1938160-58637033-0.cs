[ApiController]
<b>[Route("api", Name="DefaultAPI")]</b>
[Route("api/[controller]")]
public class DefaultController : Controller
{
    ...
    public IActionResult Index()
    {
        return Ok("abc");
    }
    ...
}
