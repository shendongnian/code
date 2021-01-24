    [Route("yourAction/{id}")]
    public IActionResult yourAction(int id)
    {
    // you will use this code to display a custom page for every error
    Response.StatusCode = id;
    return View();
    }
