    [Route("login")]
    [AllowAnonymous]
    [Authorize(AuthenticationSchemes = "OPERATOR_AUTH")]
    public IActionResult Login()
    {
      if (HttpContext.User.Identity.IsAuthenticated)
      {
        return RedirectToAction("UserInformation", "Home");
      }
      return View(new OperatorLoginModel());
    }
