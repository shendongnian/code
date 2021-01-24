        public ActionResult Index()
        {
            UsersViewModel usersViewModel = new UsersViewModel();
            usersViewModel.Access1 = new bool[] {true,false,true };
            return View(usersViewModel);
        }
