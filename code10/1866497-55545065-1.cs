    [Authorize]
    [RoutePrefix("v1/reports")]
    public class ReportV1Controller : ApiController {
    
        [Route("")]
        public IHttpActionResult GetReports() {
            //...
        }
    }
