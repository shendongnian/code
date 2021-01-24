    [RoutePrefix("internal/api/therapist")]
    public class TherapistController : ApiController
    {
        [HttpPost]
        [Route("Post/{therapistModel}")]
        public IHttpActionResult Post(TherapistModel therapistModel)
        {
            return Ok();
        }
        [HttpPost]
        [Route("Email/{therapistModel}")]
        public IHttpActionResult SendConfirmationEmail(TherapistModel therapistModel)
        {
            return Ok();
        }
    }
