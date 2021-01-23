     [HttpPost]
     public virtual ActionResult LogOn(LogOnModel model, string returnUrl)
     {
        if (ModelState.IsValid)
        {
           if (MembershipService.ValidateUser(model.UserName, model.Password))
           {
              FormsService.SignIn(model.UserName, model.RememberMe);
              FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(model.UserName, model.RememberMe, 15);
              string encTicket = FormsAuthentication.Encrypt(ticket);
              this.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
  
                        if (Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "The user name or password provided is incorrect.");
                    }
                }
