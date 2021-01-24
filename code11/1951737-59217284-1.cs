    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UserViewModels user)
    {
        if (ModelState.IsValid)
        {
            
          var u = context.Users.where(a => a.Id == UserId).FirstOrDefault();
          if(u != null)
          {
            u.UserName = user.UserName
            so on.....
            await context.SaveChangesAsync();
            return RedirectToAction("CompleteActionName");
          }
            
            return RedirectToAction("UserNotFound", user);
        }
        return View(user);
    }
