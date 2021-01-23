    public class ProjectsController: Controller
    {
        public ActionResult Index()
        {
            var projects = new[]
            {
                new ProjectNav { Id = 1, Name = "Big project in New York" },
                new ProjectNav { Id = 2, Name = "Small project in New Jersey" },
                new ProjectNav { Id = 3, Name = "Big project in Florida" },
            };
            return View(projects);
        }
    }
