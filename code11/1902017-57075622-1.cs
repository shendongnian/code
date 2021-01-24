    public class CategoriesController : ControllerBase
    {
       [HttpGet]
       public string[] My()
       {
           return new[]
           {
               "Is the Microwave working?",
               "Where can i pick the washing machine from?",
           };
       }
    }
