    //...
    public IActionResult OnGet() {
        CloseReasonType = new SelectList(context.CloseReasonTypes, nameof(CloseReasonType.Id), nameof(CloseReasonType.Name));
        return Page();
    }
    [BindProperty]
    public SelectList CloseReasonType { get; set; }
    //...
