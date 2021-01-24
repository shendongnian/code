    public class Controller : ControllerBase
	{
		private readonly IStatisticsHub _statisticsHub;
		public Controller(IStatisticsHub statisticsHub)
		{
			_statisticsHub = statisticsHub;
		}
		[HttpPost]
		public JsonResult Update(Record record)
		{
			// code omitted for brevity
			// send message to all clients
			_statisticsHub.Send("Statistics");
			return Json(new { Data = data, success = true }, JsonRequestBehavior.AllowGet);
		} 
    }
