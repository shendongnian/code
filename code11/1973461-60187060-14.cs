    //...
    private void loadCloseReasonTypes() {
        CloseReasonTypes = new SelectList(_context.CloseReasonTypes, nameof(CloseReasonType.Id), nameof(CloseReasonType.Name));
    }
    public IActionResult OnGet() {
        loadCloseReasonTypes();
        return Page();
    }
    
    public SelectList CloseReasonTypes { get; set; }
    [BindProperty]
    public Question Question { get; set; }
    //...
