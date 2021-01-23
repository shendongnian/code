    IPrincipal user = _authService.Authenticate(username, password);
    if (user == null)
    {
        ShowErrorMessage("No such user!");
        
    }
    else
    {
        ShowStatusMessage("Login successful!");
    }
