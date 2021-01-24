    public class VisitorBoardController : Controller
    {
        [HttpPost]
        public ActionResult PostMessage([FromBody] VisitorMessage message)
        { // ...
        }
    }
