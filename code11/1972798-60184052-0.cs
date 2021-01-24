    [HttpGet]
    public virtual async Task<IActionResult> GetModifiedSince([FromHeader]YourCustomHeader headers)
    {
     ...
    }
