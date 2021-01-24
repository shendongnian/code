    [Route("api/[controller]")]
    //[ApiController]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CalculateFee(CollegeGetModel collegeModel)
        {
            if (!ModelState.IsValid)
            {
                // Do whatever you want here. E.g: Logging
            }
            return await _collegeService.CalculateFee(collegeModel);
        }
    }
