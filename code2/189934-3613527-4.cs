    public class Page1Controller : Controller
    {
        private readonly IPagesRepository _repository;
        // TODO: to avoid repeating this ctor you could have 
        // a base repository controller which others derive from
        public Page1Controller(IPagesRepository repository)
        {
            _repository = repository;
        }
  
        public ActionResult Index()
        {
            var model = new Page1ViewModel();
            model.Page = _repository.ReadPage("page1");
            //model.Page = new Page
            //{
            //    Header = "Thanks for calling, how may I help you?",
            //    Buttons = new[] 
            //    {
            //        new Button { Text = "Next", Controller = "Page2" },
            //        new Button { Text = "Address", Controller = "Page3" },
            //    }
            //};
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(Page1ViewModel model, string redirectTo)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return Redirect(redirectTo);
        }
    }
