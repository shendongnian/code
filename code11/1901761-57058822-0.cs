    public async Task<IActionResult> SomeAction()
    {
        var accessToken = await HttpContext.GetTokenAsync("access_token");
        // ...
    }
