    public bool IsLockedOut
    {
        get
        {
            return _user.IsLockedOut;
        }
        set
        {
            if(value != _user.IsLockedOut)
            {
                if(value)
                {
                    // There's no way to programatically lock out a user, so either throw an InvalidOperationException or ignore it
                }
                else
                {
                    _user.UnlockUser();
                }
            }
        }
    }
