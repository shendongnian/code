    [HttpGet]
    public IActionResult Get(string str)
    {
        HttpContext.Items["Authorization"] = "XYZ";
        return RedirectToAction("B");
    }
    [HttpGet]
    public IActionResult B()
    {
        var value = HttpContext.Items["Authorization"] as string ?? HttpContext.Request.Headers.First(x => x.Key == "Authorization");
        return Ok();
    }
