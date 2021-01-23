    ...
    using FCX.Models.Auth;
    
    ...
    
    // GET: /auth/login
    [HttpPost]
    public ActionResult Login(AuthModel model)
    {
        if (ModelState.IsValid)
        {
            Login loginData = model.Login;
            
            ...
