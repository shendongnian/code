    public IActionResult Create()
    {
        // The ViewData line auto created by the scaffolding process
        // ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "AuthorID", "AuthorID");
        AuthorViewModel vm = new AuthorViewModel();
        vm.AuthorOptions = _context.Book.Select(x => new SelectListItem()
        { Value = x.AuthorID.ToString(), Text = x.Author.LastName }).ToList();
        return View(vm);
    }
