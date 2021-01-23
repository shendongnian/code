    public ActionResult Index()
    {
        ViewBag.Message = "Welcome to ASP.NET MVC!";
        ViewBag.UserId = User.UserId;
        ViewBag.UserName = User.EmailAddress;
        return View();
    }
