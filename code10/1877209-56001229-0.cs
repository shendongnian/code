if (result.Succeeded)
{
    _logger.LogInformation("User logged in.");
    if (HttpContext.User.IsInRole("ADMIN")) {
        return LocalRedirect("SomeSpecialUrl");
    }
    else {
        return LocalRedirect(returnUrl);
    }
}
