    public List<User> GetUsers(ErrorsResponseModel errors)
    {
        if (errors == null || errors.Username == null) return null;
        if (errors.Username.Count == 0) return new List<User>();
        if (errors.Nickname?.Count != errors.Password?.Count ||
            errors.Password?.Count != errors.Username.Count)
        {
            throw new InvalidDataException("Unequal number of Usernames/Passwords/Nicknames");
        }
        return errors.Username
            .Select((userName, index) =>
            new User
            {
                Name = userName,
                Nickname = errors.Nickname[index],
                Password = errors.Password[index]
            }).ToList();
    }
