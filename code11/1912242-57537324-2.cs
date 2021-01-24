    // Some model to be added to the repository
    // Just for demonstration purposes
    public class Blog
    {
        public Blog() { }
    }
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public async Task<IActionResult> SaveCategory()
        {
           // _categoryRepo.bloggingRepo.Add();
           return await Task.Run(() => 
           {
               Blog blog = new Blog();
               _categoryRepo.Add(blog);
               // return IActionResult;
           });
        }
    }
