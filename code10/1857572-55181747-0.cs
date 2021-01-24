    [Route("api/store/{storeId}/[controller]")]
    public class BookController : ControllerBase, IActionFilter
    {
        private int storeId;
        [HttpGet("{id:int:min(1)}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            // use value of storeId here
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //empty
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            string value = context.RouteData.Values["storeId"].ToString();
            int.TryParse(value, out storeId);
        }
    }
