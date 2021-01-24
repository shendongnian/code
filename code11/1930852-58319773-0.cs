[ApiController]
[Route("[controller]")]
public class SomeNameController : ControllerBase
{
	public SomeNameController()
	{
	}
	[HttpPost]
	public string Get((int id)
	{
		return "cat";
	}
}
