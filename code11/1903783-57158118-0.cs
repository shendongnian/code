    public IActionResult OnGet()
    {
        Response.StatusCode = 400;
        return new JsonResult(new { message = "Error" } );
    }
