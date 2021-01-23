    Public ActionResult Index ()
    {
       UserViewModel vm = new UserViewModel();
       UpdateModel(vm);// it will do same thing that was previously handled automatically by mvc
    }
