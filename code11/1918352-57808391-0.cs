    public IPasswordHasher PasswordHasher { get; set; }
    public object Any(AllowPassword request)
    {
        var passwordHashes = MyRepo.GetExistingUserPasswords(GetSession().UserAuthId);
        foreach (var passwordHash in passwordHashes)
        {
            if (PasswordHasher.VerifyPassword(passwordHash, request.Password, out var neeedsRehash)
                throw new ArgumentException("Can't use existing password", nameof(request.Password));
        }
        return new AllowPasswordResponse();
    }
