 private ApplicationSignInManager _signInManager;
 public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? 
                HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
Add the following code after changing the roles:
  var userinDb = _context.Users.Find(UserID);
  await SignInManager.SignInAsync(userinDb, true,false);
  return RedirectToAction("Success");
