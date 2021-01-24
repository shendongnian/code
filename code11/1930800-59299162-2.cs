    public async Task<IActionResult> Get()
    {
        var path = Path.Combine(
        Directory.GetCurrentDirectory(), "wwwroot\\images\\4.pdf");
        var memory = new MemoryStream();
        using (var stream = new FileStream(path, FileMode.Open))
        {
           await stream.CopyToAsync(memory);
        }
        memory.Position = 0;
        return File(memory, "application/pdf", "Demo.pdf");
    }
