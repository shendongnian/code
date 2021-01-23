    public HomeController(IUserService service)
    {
        using (var disposable = service.Wrap())
        {
            var user = service.GetUser();
            // I can even grab it again, implicitly.
            IUserService service2 = disposable;
        }
    }
