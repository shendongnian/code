    public class CustomControllerBase : ControllerBase
    {
        public ActionResult Success(string message)
        {
            return base.Ok(message);
        }
        public new ActionResult Ok(object value)
        {
            throw new Exception("don't use this");
        }
    }
    public class UserController : CustomControllerBase
    {
        public async Task<ActionResult> Hello()
        {
            return Ok("hello"); // throws runtime exception
        }
    }
