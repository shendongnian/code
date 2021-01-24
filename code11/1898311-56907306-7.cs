    [RoutePrefix("api/TidalBatchConsolidated")]
    public class TidalBatchConsolidatedController: ApiController {
        //GET api/TidalBatchConsolidated/BAM
        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(string id) {
            //...
        }
    
    }
