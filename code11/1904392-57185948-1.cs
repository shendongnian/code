    public ActionResult Index()
        {
                    ViewBag.Title = "Home Page";
                    var a= new List<CheckBox> {  };
                    a.Add(new CheckBox("c1", true));
                    a.Add(new CheckBox("c2", false));
                    a.Add(new CheckBox("c3", true));
                    ViewBag.checks =a;
        
                    UsersViewModel usersViewModel = new UsersViewModel();
                    usersViewModel.Access = a.ToArray();
                    return View(usersViewModel);
        }
 
   
