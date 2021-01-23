    public SomeController : Controller
    {
       private IUnitOfWork _unitOfWork;
       private IUserRepo _userRepo;
       private IPostRepo _postRepo;
    
       public SomeController(IUnitOfWork unitOfWork, IUserRepo userRepo, IPostRepo postRepo)
       {
          _unitOfWork = unitOfWork; // use DI to resolve EntityFrameworkUnitOfWork
          _userRepo = userRepo;
          _postRepo = postRepo;
       }
    
       [HttpPost]
       public ActionResult CreateUserAndPost(User user, Post post)
       {
          // at this stage, a HTTP request has come in, been resolved to be this Controller
          // your DI container would then see this Controller needs a IUnitOfWork, as well
          // as two Repositories. DI smarts will resolve each dependency.
          // The end result is a single DataContext (wrapped by UoW) shared by all Repos.
          try
          {
             userRepo.Add(user);
             postRepo.Add(post);
             // nothing has been sent to DB yet, only two objects in EF graph set to EntityState.Added
             _unitOfWork.Commit(); // two INSERT's pushed to DB
          }
          catch (Exception exc)
          {
              ModelState.AddError("UhOh", exc.ToString());
          }
       }
    }
