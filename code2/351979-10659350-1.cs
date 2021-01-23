    public void UserJoin(User user)
    {
      user.CanJoin
        ? GreetUser(user)
        : RejectUser(user);
    }
    public void Greetuser(User user)
    {
      messages.Greeting(user);
    }
    public void RejectUser(User user)
    {
      messages.Reject(user);
      this.kick(user);
    }
