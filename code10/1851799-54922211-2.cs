    public Task SetPasswordHashAsync(TUser user, string passwordHash,
         CancellationToken cancellationToken)
    {
        user.PasswordHash = passwordHash;
        return Task.FromResult(0);
    }
    public Task<string> GetPasswordHashAsync(TUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult<string>(user.PasswordHash);
    }
    public Task<bool> HasPasswordAsync(TUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult<bool>(!String.IsNullOrEmpty(user.PasswordHash));
    }
