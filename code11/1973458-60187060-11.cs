    //...
    private void loadCloseReasonTypes() {
        CloseReasonTypes = new SelectList(_context.CloseReasonTypes, nameof(CloseReasonType.Id), nameof(CloseReasonType.Name));
    }
    public IActionResult OnGet() {
        loadCloseReasonTypes();
        return Page();
    }
    [BindProperty]
    public SelectList CloseReasonTypes { get; set; }
    //...
