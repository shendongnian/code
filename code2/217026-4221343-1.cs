    public override int GetHashCode()
    {
       //I'm going to assume that different
       //people with the same SocialSecurityNumber are extremely rare,
       //as optimise by hashing on that alone. If this isn't the case, change this
       return SocialSecurityNumber.GetHashCode();
    }
