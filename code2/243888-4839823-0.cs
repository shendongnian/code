    public class PostsController: Controller
    {
        private readonly IPostsRepository _repository;
        public PostsController(IPostsRepository repository)
        {
            _repository = repository;
        }
    
        public ActionResult Index()
        {
            var posts = _repository.GetAllPosts();
            return View(posts);
        }
    }
