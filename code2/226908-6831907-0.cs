    public User FindByEmail(Email email)
    {
        return session.GetCollection<User>().AsQueryable()
               .Where(u => u.EmailAddress.ToLower() == email.Address.ToLower()).FirstOrDefault();
    }
