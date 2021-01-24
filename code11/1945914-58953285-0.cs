    [Route("contact")]
    [ApiController]
    public class ContactController : ControllerBase
        [HttpGet("{customerId}/{contractId}")]
        public IActionResult GetContact(int customerId, int contactId)
        {
        }
