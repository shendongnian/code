    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> RemoveUser()
    {
    return RedirectToAction("Index", "Home");
    }
