    [RoutePrefix("api/search")]
    public class SearchController : ApiController {
        //...
        //GET api/search/word
        [HttpGet]
        [Route("{search}")]
        public IHttpActionResult GetSearch(string search) {           
            var results = getyoutuberesults(search);
            return Ok(results);
        }
    
        //...
    }
