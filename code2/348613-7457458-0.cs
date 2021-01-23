    private string _channel;
    public void OnPublic(UserInfo user, string channel, string message)
    {
       _channel = channel;
      //..
    }
