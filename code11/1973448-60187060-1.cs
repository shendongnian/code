    //...
    public IActionResult OnGet() {
        CloseReasonType = new SelectList(_context.CloseReasonTypes, nameof(CloseReasonType.Id), nameof(CloseReasonType.Name));
        return Page();
    }
    [BindProperty]
    public SelectList CloseReasonType { get; set; }
    //...
