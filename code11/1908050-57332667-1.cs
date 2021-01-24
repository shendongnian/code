    public IActionResult OnGetPng()
    {
        var bytes = System.IO.File.ReadAllBytes("test.png");
        var cd = new System.Net.Mime.ContentDisposition
        {
            FileName = "test.png",
            Inline = false
        };
        Response.Headers.Add("Content-Disposition", cd.ToString());
        Response.Headers.Add("X-Content-Type-Options", "nosniff");
        return File(bytes, "image/png");
    }
