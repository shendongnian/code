    void Method(Status status)
    {
        User user = context.Users.Where(u => u.Id = 1).First();
    
        context.Attach(status);
        user.Status = status;
    
        context.SaveChanges();
    }
