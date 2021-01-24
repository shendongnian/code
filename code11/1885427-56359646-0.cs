        public async Task<IActionResult> Index()
        {
            AppUser user = await userManager.GetUserAsync(HttpContext.User);
            Debug.WriteLine(user.Id);
            Debug.WriteLine(user.UserName);
            Debug.WriteLine(user.Email);
            return View();
        }
    
