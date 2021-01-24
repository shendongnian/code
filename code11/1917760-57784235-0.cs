    [Authorize]
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class PermissionsController : ControllerBase
	{
		private readonly PlanraumContext _context;
		public PermissionsController(PlanraumContext context)
		{
			_context = context;
		}
		
		[Route("/api/[controller]/group/[action]")]
		[HttpGet]
		public ActionResult Get(int folderId)
		{
			return Ok(new PermissionHelper(_context).GetGroupPermissions(folderId));
		}
	}
