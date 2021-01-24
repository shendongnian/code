    [RoutePrefix("api/IDM")]
    public class IDMController : ApiController {
    
        //...
        //POST api/IDM/CheckForDuplicateID
        [HttpPost]
        [Route("CheckForDuplicateID")]
        public DuplicateCheck CheckForDuplicateID([FromBody] DuplicateCheck m) {
            ....code 
        }
    }
