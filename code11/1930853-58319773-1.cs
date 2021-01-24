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
**Update**
JS
var accountNumber = parseInt(selectedAccountNumber, 10);
var data { id : accountNumber };
var url = '@Url.Action("GetAccountName", "Statements")';
$.post(url, data);
