    [HttpGet]
    public IActionResult Get(string str)
    {
        TempData["Authorization"] = "XYZ";
        return RedirectToAction("B");
    }
    [HttpGet]
    public IActionResult B()
    {
        if (TempData.Contains("Authorization")) {
            HttpContext.Request.Headers.Remove("Authorization");
            HttpContext.Request.Headers.Add("Authorization", TempData["Authorization"]);
        }
        var value = HttpContext.Request.Headers.First(x => x.Key == "Authorization");
        return Ok();
    }
