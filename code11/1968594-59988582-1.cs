    @await Component.InvokeAsync("IdentifierValidation", new { date = Model.Date })
    @if (ViewContext.HttpContext.Items["InvalidIdentifier"] != null)
    {
        ViewData.ModelState.AddModelError("InvalidIdentifier", "An Invalid Identifier has been Detected!");
    }
