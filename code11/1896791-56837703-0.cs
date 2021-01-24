// GET: Categories/Edit/5
public async Task<IActionResult> Edit(int? id)
{
    // Fail early here, no reason to check the DB if 
    // the user doesn't include the right information
    if (id == null)
    {
        return NotFound();
    }
    var currentUser = await _userManager.GetUserAsync(HttpContext.User);
    // First, look up the category the user is attempting to access
    var category = await _context.Categories.FindAsync(id);
    // Check that the category the user is accessing belongs to them
    if (category.ApplicationUserId != currentUser.Id)
    {        
        return RedirectToAction(nameof(Index));
    }
    return View(category);
}
