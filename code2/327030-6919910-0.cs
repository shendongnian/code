    public class TimeController: Controller
    {
            [HttpPost]
            public JsonResult GetTime(int offset)
            {
               return new JsonResult { Time= DateTime.Now().AddHours(offset) };
            }
    }
