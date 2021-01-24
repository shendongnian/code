    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : Controller
    { 
        [HttpGet("GetInfo")]
        public async Task<IActionResult> GetInfoAsync()
        {
            Statuses statuses = null;
            try
            {
                statuses = await BusinessComponent.GetInfo();
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Exception occurred while trying to get health informations.");
            }
            return Ok(statuses);
        }
    }
