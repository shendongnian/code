    [MyActionFilter]
    public IActionResult Get()
        {
            var id = HttpContext.Items["CurrentUserId"]?.ToString();
            //...
        }
