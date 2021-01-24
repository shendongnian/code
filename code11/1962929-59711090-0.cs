    public ActionResult Login(string UserName)
            {
                ViewBag.UserName=username; 
                return View();
            }
    
            [HttpPost]
            public ActionResult Register(Account account)
            {
                if (!db.Accounts.Any(x => x.Username.Equals(account.Username)))
                {
                    Account acc = new Account()
                    {
                        Username = account.Username,
                        Password = account.Password,
                        CreatedDate = DateTime.UtcNow,
                        IsDeleted = false,
                    };
                    db.Accounts.Add(acc);
                    db.SaveChanges();
    
                    FormsAuthentication.SetAuthCookie(acc.AccountID.ToString(), false);
                    ViewBag.Success = "User registered. You may login now!";
                    return RedirectToAction("Login", "Account",account.Username);
                }
                else
                {
                    ViewBag.Error = "User already exist!";
                    return View();
                }
            }
