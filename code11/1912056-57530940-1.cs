    public static void RecordInvalidLoginAttempt(this IUserAuthRepository repo, IUserAuth userAuth)
    {
        var feature = HostContext.GetPlugin<AuthFeature>();
        if (feature?.MaxLoginAttempts == null) return;
        userAuth.InvalidLoginAttempts += 1;
        userAuth.LastLoginAttempt = userAuth.ModifiedDate = DateTime.UtcNow;
        if (userAuth.InvalidLoginAttempts >= feature.MaxLoginAttempts.Value)
        {
            userAuth.LockedDate = userAuth.LastLoginAttempt;
        }
        repo.SaveUserAuth(userAuth);
    }
