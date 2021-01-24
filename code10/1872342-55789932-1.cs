    [HttpGet("/{url1}")]
    [HttpGet("/{url1}/{url2}")]
    [HttpGet("/{url1}/{url2}/{url3}")]
    [HttpGet("/{url1}/{url2}/{url3}/{url4}")]
    public IActionResult Test(string url1 = null, string url2 = null, string url3 = null, string url4 = null)
    {
        var url = string.Join("/", url1, url2, url3, url4);
        //... return View();
    }
