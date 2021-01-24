    //...
    public IActionResult OnGet() {
        CloseReasonType = new SelectList(_context.CloseReasonTypes, "Id", "Name");
        return Page();
    }
    [BindProperty]
    public SelectList CloseReasonType { get; set; }
    //...
