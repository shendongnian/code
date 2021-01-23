    public class MyController : Controller
    {
        public ActionResult Index()
        {
            var posts = db.GetTable<Post>();
            ViewData["Posts"] = posts;
    
            return RespondTo(new ActionResultChoiceMap
            {
                { "html", () => View()      },
                { "json", () => Json(posts) },
            });
        }
    }
