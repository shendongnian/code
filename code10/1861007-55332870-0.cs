    public async Task<IActionResult> OnGet()
    {
        var result = await _db.Person.ToListAsync();
        Person = result.OrderBy(x => x.LastName);
        return Page(); 
    }
