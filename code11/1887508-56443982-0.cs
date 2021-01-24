    public class Default: Controller
        {
            [HttpPost] // This attribute states that this action result can only be accessed when using http POST verb.
            public IActionResult Submit()
            {
                return RedirectToAction("index", "home");
            }
           
        }
