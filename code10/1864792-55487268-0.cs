    public class TaskController : ApiController
	{
		[HttpGet]
		[Route("GetAffectedCIs/{number}")]
		public ListResponse<TaskCiResultFlat> GetAffectedCIs(string number)
		{
			......
		}
	}
