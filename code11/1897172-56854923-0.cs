    [HttpPost("{id}"]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, ApplicationUserViewModel model)
    {            
        if (!ModelState.IsValid)
            return View(model);
        
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
            return NotFound();
        user.FirstName = model.FirstName;
        user.LastName = model.LastName;
        // etc. You can also use a mapping library like AutoMapper instead
        var result = await _userManager.UpdateAsync(user);
        if (result.Succeeded)
        {
            // db.Entry(listdata).State = EntityState.Modified;
            // db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(user);
    }
