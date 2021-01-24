    [HttpPost]
    public ActionResult Register(UserAccount user)
    {
        if (ModelState.IsValid)
        {
            _context.UserAccounts.Add(user);
            _context.SaveChanges();
            TempData["Message"] = "Successfully Registration Done";
            return RedirectToAction("Foo");
        }
        return View();
    }
