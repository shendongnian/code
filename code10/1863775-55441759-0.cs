    public override bool Equals(object obj)
    {
        var user= obj as User;
        if (user == null)
        {
            return false;
        }
        return user.Id == this.Id;
    }
