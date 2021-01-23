    public class HomeController : Controller
    {
        public HomeController()
        {
        }
        public ActionResult Index()
        {
            List<Comment> comments;
            using (var conn = new SqlConnection(/* ... */))
            {
                conn.Open();
                comments = conn.ExecuteMapperQuery<Comment>("select * from Comment");
            }
            return View(comments);
        }
    }
