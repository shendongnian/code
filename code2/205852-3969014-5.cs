    public virtual bool HasRightsTo<T>(T authorizationSpec) where T:IUserRights{
      return authorizationSpec.IsSatisfiedBy(this);
    }
    public virtual void CheckRightsFor<T>(T authorizationSpec) where T:IUserRights{
      authorizationSpec.CheckRightsFor(this);
    }
