    [Authorize]
    [RoutePrefix("v1/reports")]
    public class ReportV1Controller : ApiController {
    
        //GET v1/reports
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetReports() {
            //...
        }
    }
