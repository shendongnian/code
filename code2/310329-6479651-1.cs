    public virtual ActionResult Register (Guid? registrationToken)
    {
        if(registrationToken.HasValue)
        {
             // this is specific user
        }         
        else
        {
             // this is general user
        }
    }
