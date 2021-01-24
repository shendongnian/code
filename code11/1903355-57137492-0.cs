    [HttpPost]
    public IActionResult Login(LoginViewModel loginViewModel)
    {
        loginViewModel.plainTextPassword = loginViewModel.user.Password;
        var userInfo = _context.Users.Where(x => x.Email == loginViewModel.user.Email)
            .Select(x => new 
            {
                x.UserId,
                x.FirstName,
                x.LastName,
                x.Password,
                IsAdmin = x.Permissions.Admin
            }).SingleOrDefault();
        if (userInfo == null)
        {
            ViewBag.Error = "Sorry, but we couldn't log you in.";
            return View();
        }
        else if (Hashing.Confirm(loginViewModel.plainTextPassword, userInfo.Password, Supported_Ha.SHA256))
        {
            HttpContext.Session.SetString("UserFirstName", userInfo.FirstName);
            HttpContext.Session.SetString("UserLastName", userInfo.LastName);
            HttpContext.Session.SetInt32("UserUserId", userInfo.UserId);
            HttpContext.Session.SetString("IsAdmin", userInfo.IsAdmin.ToString());
            ViewBag.IsAdmin = userInfo.IsAdmin.ToString();
            ViewBag.SessionUserName = userInfo.FirstName;
            return RedirectToAction("Index");
        }
        ViewBag.Error = "Sorry, but we couldn't log you in.";
        return View("Index");
    }
