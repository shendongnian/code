    [BindProperty]
    public IFormFile Upload { get; set; }
    
    public async Task OnPostAsync()
    {
        var file = Path.Combine(_environment.ContentRootPath, "uploads", Upload.FileName);
        using (var fileStream = new FileStream(file, FileMode.Create))
        {
            await Upload.CopyToAsync(fileStream);
        }
    }
