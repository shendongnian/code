    // POST: /Account/Register
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Register(RegisterViewModel model)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var user = new User() { UserName = model.Email, Email = model.Email  };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    AddErrors(result);
                }
            }
    
            // If we got this far, something failed, redisplay form
            return View(model);
        }
        catch (DbEntityValidationException ex)
        {
            foreach (var errors in ex.EntityValidationErrors)
            {
                foreach (var validationError in errors.ValidationErrors)
                {
                    // get the error message 
                    string errorMessage = validationError.ErrorMessage;
                    //Or log your error message here
                }
            }
            throw;
        }        
    }
