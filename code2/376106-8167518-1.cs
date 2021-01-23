    void SomeMethod()
    {
      if(!this.IsOwnedByCurrentUser())
      {
        PrincipalPermission pp = new PrincipalPermission(null, "SomeSpecialGroup");
        pp.Demand();
      }
    }
