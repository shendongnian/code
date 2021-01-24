    [NotMapped]
    public bool? Status
    {
        get 
        { 
            if(IsApproved().Invoke(this))
                return true;
            if(IsRejected().Invoke(this))
                return false;
            return null;
        }
    }
