    public async Task<IActionResult> OnPostAsync() {
        if (!ModelState.IsValid) {
            CloseReasonType = new SelectList(_context.CloseReasonTypes, "Id", "Name");
            return Page();
        }
        _context.Question.Add(Question);
        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
    }
