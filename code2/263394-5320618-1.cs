    public bool UnVerifiedOrActive(User user)
    {
        return (user.UserStatus == UserStatus.Unverified || 
                user.UserStatus == UserStatus.Active);
    }
