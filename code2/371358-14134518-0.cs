    public class MyController : Controller
    {
        static MemoryCache s_cache = new MemoryCache("myCache");
        public ActionResult Index()
        {
            if (conditionThatInvalidatesCache)
            {
                s_cache = new MemoryCache("myCache");
            }
            String s = s_cache["key"] as String;
            if (s == null)
            {
                //do work
                //add to s_cache["key"]
            }
            //do whatever next
        }
    }
