    public async Task<IActionResult> Index(int? id)
    {
        var kolaycam_acsgoContext = _context.siparis_detay
            .Where(s => s.Siparis_no == id);
        return View(await kolaycam_acsgoContext.ToListAsync());
    }
