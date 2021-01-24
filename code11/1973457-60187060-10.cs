    public async Task<IActionResult> OnPostAsync() {
        if (!ModelState.IsValid) {
            CloseReasonTypes = new SelectList(_context.CloseReasonTypes, nameof(CloseReasonType.Id), nameof(CloseReasonType.Name));
            return Page();
        }
        _context.Question.Add(Question);
        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
    }
