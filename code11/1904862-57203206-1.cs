    [HttpGet]
    public IActionResult Get(string str)
    {
        // The request comes with a request header with key "Authorization" and value "ABC"
        HttpContext.Request.Headers.Remove("Authorization");
        HttpContext.Request.Headers.Add("Authorization", "XYZ");
        return B();
    }
