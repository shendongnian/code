    [Route("~/yourAction/{id}")]
    public IActionResult yourAction(int code)
    {
    // you will use this code to display a custom page for every error
    Response.StatusCode = code;
    return View();
    }
