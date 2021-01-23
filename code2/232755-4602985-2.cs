    [HttpGet]
    public ViewResult Index() {
      var model = new RegisterViewModel();
      model.Roles = System.Web.Security.Roles.GetAllRoles(); //or however you populate your roles
      return View(model);
    }
    [HttpPost]
    public ActionResult Index(RegisterViewModel model) {
      string[] roles = model.Roles //the selected roles are here
      //....
    }
