    [Route("api/[controller]")]
    [ApiController]
    public class SitesController : ControllerBase {
        [HttpGet("{siteId:length(24)}")]
        public ActionResult<Site> Get(string siteId) {}
    }
    [Route("api/sites/{siteId:length(24)}/[controller]")]
    [ApiController]
    public class ReadersController {
        [HttpGet]
        public string Get() => "test";
    
        [HttpGet("{readerId:length(24)}")]
        public ActionResult<Site> Get(string siteId, string readerId) {}
    }
