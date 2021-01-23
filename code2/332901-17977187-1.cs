	public class TestController : Controller
	{
		public string GetMyId()
		{
			//ANSWER -> ControllerContext.RouteData.Values["id"]
			return ControllerContext.RouteData.Values["id"].ToString();
		}
	}
