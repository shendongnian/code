    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {        
        [Route("{provider}/AvailableSlots")]
        [HttpGet]        
        public Task<AvailableSlotsResponse> GetAvailableSlots(AvailableSlotsRequest request)
        {
            return null;
        }
    }
    public class Request
    {
        [FromRoute]
        public string ProviderName { get; set; }
    }
    public class AvailableSlotsRequest : Request
    {
        [FromQuery]
        public string Location { get; set; }
    }
