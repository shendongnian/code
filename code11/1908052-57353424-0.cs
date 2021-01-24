    public async Task<IActionResult> DownloadImage(string filename)
    {
        var path = Path.GetFullPath("./wwwroot/images/school-assets/" + filename);
        MemoryStream memory = new MemoryStream();
        using (FileStream stream = new FileStream(path, FileMode.Open))
        {
            await stream.CopyToAsync(memory);
        }
        memory.Position = 0;
        return File(memory, "image/png", Path.GetFileName(path));
    }
