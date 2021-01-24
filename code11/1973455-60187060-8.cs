    //...
    public IActionResult OnGet() {
        CloseReasonTypes = new SelectList(_context.CloseReasonTypes, nameof(CloseReasonType.Id), nameof(CloseReasonType.Name));
        return Page();
    }
    [BindProperty]
    public SelectList CloseReasonTypes { get; set; }
    //...
