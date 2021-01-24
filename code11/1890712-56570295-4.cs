    [Route("page")]
    public class PageController : Controller
    {
        [Route("OnGetCampaign/{selId}")]
        public IActionResult Demo2(string selId)
        {
            return new JsonResult("Hello " + selId);
        }
    }
