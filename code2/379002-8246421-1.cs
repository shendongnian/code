    public ActionResult Index()
    {
        var fakePerms = new List<FooPermissionModel> () 
        { 
            new FooPermissionModel { Name = "Foo1", Reason = "Boo", Selected=true }, 
            new FooPermissionModel { Name = "Bazz", Reason = "Tootsie", Selected=false }
        };
    
        var model = new FooManagementDetailViewModel();
        model.FooPermissions = fakePerms;
    
        return View(model);
    }
