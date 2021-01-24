    public IActionResult GetSomething(SomethingRequest request)
    {
        var validationResult = _requestValidationService.ValidateToken(request?.Token);
        if (!validationResult.Succeeded)
        {
            return new StatusCode(validationResult.StatusCode, validationResult.Message);
        }
    }
