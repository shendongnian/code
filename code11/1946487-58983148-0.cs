csharp
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class OrganizationsController : BaseController
{
	[HttpGet("{id}")]
	public async Task<IActionResult> GetOrganization(string id)
	{
		var command = new GetOrganizationQuery(id);
		return Ok(await Mediator.Send(command));
	}
	
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	public async Task<IActionResult> CreateOrganization(CreateOrganizationCommand command, ApiVersion version)
	{
		var organization = await Mediator.Send(command);
		return CreatedAtAction(nameof(GetOrganization),
			new { id = organization.Id, version = version.ToString() }, 
			organization);
	}  
}
You can see more [here](https://github.com/Microsoft/aspnet-api-versioning/issues/409).
