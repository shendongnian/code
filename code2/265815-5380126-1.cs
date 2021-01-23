    public virtual void AddGroup(UserGroup userGroup)
    {
        if(!this.UsersGroups.Contains(userGroup))
        {
             this.UsersGroups.Add(userGroup);
             userGroup.Users.Add(this); 
        }
    }
