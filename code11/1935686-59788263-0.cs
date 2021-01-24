    public class InvoiceController : Controller
    {
        [HttpGet("~/invoice/{sessionId}")]
        public async Task<IActionResult> Invoice(string sessionId, CancellationToken cancel)
        {
            return File(...);
        }
    }
