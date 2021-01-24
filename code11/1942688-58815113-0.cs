public async Task<IActionResult> Index(string searchString)
    {
        var requests = from m in _context.RaidRequest select m;
        if (!String.IsNullOrEmpty(searchString))
        {
            requests = requests.Where(s => s.Reason.Contains(searchString) || s.UNCPath.Contains(searchString) || s.Department.Contains(searchString));
        }
        return View(await requests.ToListAsync());
    }
