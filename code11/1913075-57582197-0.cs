    [RoutePrefix( "api/ShapeFileAnalysis" )]    //  new line of code!
    public class ShapeFileAnalysisController : ApiController
    {
        [HttpGet]
        [Route("GetDataValues")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage GetDataValues()
        {
        }  
    }
