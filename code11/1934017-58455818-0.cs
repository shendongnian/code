    baseUrl/reviews?sortDirection=asc&sortField=time&filterField=rating&filterValue=9&page=1&items=10
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        public JsonResult Search(string sortDirection, string sortField, string filterField, string filterValue, int page, int items)
        // I would also recommend returning IHttpActionResult, much more robust
        {
            ... getting data from db be here ..
        }
    }
