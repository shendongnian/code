csharp
[Route("health")]
[ApiController]
public class HealthController : Controller
{
    [HttpGet("some_health_url")]
    public ActionResult SomeHealthMethod() {}
}
[Route("v2")]
[ApiController]
public class V2Controller : Controller
{
    [HttpGet("some_url")]
    public ActionResult SomeV2Method()
    {
        return RedirectToAction("SomeHealthMethod", "Health"); // omit "Controller"
    }
}
If you try to use any of the url-specific strings, e.g. `"some_health_url"`, it will not work!
