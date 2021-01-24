    // Page A
    public async Task<IActionResult> OnPostAsync() 
    {
     //...
     RedirectToPage("PageB", new { PrimaryKey = value});
    }
    
    // Page B
    public async Task<IActionResult> OnGetAsync(string PrimaryKey)
    {
     // use your key
    }
