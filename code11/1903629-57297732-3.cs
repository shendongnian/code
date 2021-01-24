    
    [Authorize(nameof(Policies.TimeMustBeEvening))]
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
       /* ... */
    }
