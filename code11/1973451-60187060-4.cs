    public async Task<IActionResult> OnPostAsync() {
        if (!ModelState.IsValid) {
            CloseReasonType = new SelectList(_context.CloseReasonTypes, nameof(CloseReasonType.Id), nameof(CloseReasonType.Name));
            return Page();
        }
        Question.ClosedReasonId = Question.CloseReasonType.Id;
        _context.Question.Add(Question);
        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
    }
