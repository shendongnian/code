    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        var record = _context.Fileset.Find(id); // <-- id should be part of the POST
        record.Ticket = "Some random text";
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FilesetExists(Fileset.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
   
        return RedirectToPage("./Index");
    }
