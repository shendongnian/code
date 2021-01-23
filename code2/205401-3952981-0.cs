    public ActionResult LogOn(LogOnModel model, bool rememberMe, string returnUrl)
            {
                if (ModelState.IsValid)
                {
                    if (MembershipService.ValidateUser(model.UserName, model.Password))
                    {
                        FormsService.SignIn(model.UserName, rememberMe);
                        if (!String.IsNullOrEmpty(returnUrl))
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
    
                // If we got this far, something failed, redisplay form
                return View(model);
            }
