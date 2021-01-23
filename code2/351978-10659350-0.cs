    public void UserJoin(User user)
    {
      if (verify.CanJoin(user))
      {
        messages.Greeting(user);
      }
      else
      {
        this.kick(user);
      }
    }
