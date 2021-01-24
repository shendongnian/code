    public IActionResult FormatFile()
    {
        var webroot = _env.WebRootPath;
        var filepath = TempData["filepath"].ToString();
        string[] reader = System.IO.File.ReadAllLines(Path.Combine(webroot, filepath));
        foreach (var line in reader)
        {
			System.IO.File.WriteAllLines(filepath, line.Replace(" ", ","));
        }
        return Content(System.IO.File.ReadAllText(filepath));
    }
