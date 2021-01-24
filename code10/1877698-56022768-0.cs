    public override async Task<token> SendTwoFactorCodeAsync(string provider)
    {
      TKey userId = await this.GetVerifiedUserIdAsync().WithCurrentCulture<TKey>();
      if ((object) userId == null)
        return false;
      string token = await this.UserManager.GenerateTwoFactorTokenAsync(userId, provider).WithCurrentCulture<string>();
      IdentityResult identityResult = await this.UserManager.NotifyTwoFactorTokenAsync(userId, provider, token).WithCurrentCulture<IdentityResult>();
      return token;
    }
