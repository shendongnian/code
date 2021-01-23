    using (var _cnt = new STQContext())
    {
       _cnt.Users.Attach(user);
       _cnt.Entry<User>(user).Property(u => u.PasswordHash).IsModified = true;
       _cnt.SaveChanges();
    }
