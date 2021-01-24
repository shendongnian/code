    [Authorize]
    public IActionResult BannerImage()
    {
        var file = Path.Combine(Directory.GetCurrentDirectory(), 
                                "MyStaticFiles", "images", "banner1.svg");
    
        return PhysicalFile(file, "image/svg+xml");
    }
