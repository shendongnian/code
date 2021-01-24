    if (_httpContext.User.Identity.IsAuthenticated)
                    await this.UserIdentitySignOutAsync(_httpContext, _context);
                else
                {
                    var value = _httpContext.Session.GetString("RedirectToLogin");
                    bool.TryParse(value, out bool redirectToLogin);
    
                    if (redirectToLogin)
                    {
                        Feedback = new Feedback() { Message = "Your session has expired.", IsValid = false };
                        _httpContext.Session.SetString("RedirectToLogin", false.ToString());
                    }
                }
