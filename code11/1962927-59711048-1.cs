    public ActionResult Login(string userName)
    {
       return View();
    }
    
     [HttpPost]
     public ActionResult Register(Account account)
     {
       ...
       return RedirectToAction("Login", "Account", new {userName=account.Username});               
                
     }
