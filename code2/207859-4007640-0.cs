    public override string GetUserNameByEmail(TemplateEntities ctx, string email)
    {
        return (from u in ctx.Users
                where u.Email == email
                select u.UserName).SingleOrDefault();
    }
    public User GetUser(TemplateEntities ctx, string username)
    {
        return (from u in ctx.Users
                where u.UserName == username
                select u).FirstOrDefault();
    }
