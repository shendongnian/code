    using (PrincipalContext _loginContext = new PrincipalContext(ContextType.Domain, "domainname"))
    {
        _message += "calling ValidateCredentials";
        _isAuthSuccess = _loginContext.ValidateCredentials(model.Email, model.Password);
    }
    
    using (PrincipalContext _loginContext = new PrincipalContext(ContextType.Domain, "domainname", "username", "password"))
    {
        if(_isAuthSuccess)
        {
            ...
        }
        else
        {
            _message += "_isAuthSuccess is false";
        }
    }
