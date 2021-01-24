    public async Task<IActionResult> OnPostAsync() {
        if (!ModelState.IsValid) {
            loadCloseReasonTypes();
            return Page();
        }
        _context.Question.Add(Question);
        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
    }
