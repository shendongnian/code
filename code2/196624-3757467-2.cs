    public static User ToUserEntity(this DbUser user)
    {
        return new User
        {
            Uid = user.uid,
            FirstName = user.first_name,
            LastName = user.last_name
        };
    }
