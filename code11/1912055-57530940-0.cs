    public virtual bool TryAuthenticate(IServiceBase authService, string userName, string password)
    {
        var authRepo = GetUserAuthRepository(authService.Request);
        using (authRepo as IDisposable)
        {
            var session = authService.GetSession();
            if (authRepo.TryAuthenticate(userName, password, out var userAuth))
            {
                if (IsAccountLocked(authRepo, userAuth))
                    throw new AuthenticationException(ErrorMessages.UserAccountLocked.Localize(authService.Request));
                session.PopulateSession(userAuth, authRepo);
                return true;
            }
            return false;
        }
    }
