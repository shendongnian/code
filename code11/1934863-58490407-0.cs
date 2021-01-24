    [RoutePrefix("api/Report")]
    public class ReportController : ApiController {
        //POST api/Report/Test
        [HttpPost]
        [Route("Test")]
        public IHttpActionResult Test([FromBody]Test model) {
            if(ModelState.IsValid) {
                //...
                return Ok();
            }
            return BasRequest(ModelState);
        }
    }
