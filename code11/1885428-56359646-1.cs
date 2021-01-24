        public async Task<IActionResult> createpost()
        {
            var userData = await mUserManager.GetUserAsync(HttpContext.User);
            Debug.WriteLine(userData.Id);
            Debug.WriteLine(userData.UserName);
            Debug.WriteLine(userData.Email);
            return View();
        }
    
