    public class BlogsController : Controller
    {
        public ActionResult List()
        {
            return View(GetPostsOrSomething());
        }
        public ActionResult Posts(int id)
        {
            return View(new BlogViewModel(id));
        }
    
        [HttpPost]
        public ActionResult Comment(int id, string comment)
        {
            // do comment
        }
    }
