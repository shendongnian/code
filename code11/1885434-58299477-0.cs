    [RoutePrefix("api/City")]
    public class CityController : Controller
    {
        [HttpPut]
        [Route("DeleteCitys")]
        public async Task<int> DeleteCitys(Guid[] Id)
        {
            // Your Code
        }
        [HttpPut]
        [Route("DeleteCitys/{Id}")]
        public async Task<int> DeleteCitys(Guid? Id)
        {
            // Your Code
        }
    }
