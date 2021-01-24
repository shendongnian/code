    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }
    
    var user = await _userManager.FindByNameAsync(model.UserName);
    ...
    return View(result);
