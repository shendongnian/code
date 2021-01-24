    [RoutePrefix("api/TidalBatchConsolidated")]
    public class TidalBatchConsolidatedController: ApiController {
        //GET api/TidalBatchConsolidated
        [Route("")] //Default route
        [HttpGet]
        public IHttpActionResult GetAll() {
            //...
        }
        //GET api/TidalBatchConsolidated/BAM
        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(string id) {
            //...
        }
    
    }
