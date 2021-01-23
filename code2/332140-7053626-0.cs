    // this method we will use to analyse queries (also known as private messages)
    public static void OnQueryMessage(object sender, IrcEventArgs e)
    {
        switch (e.Data.MessageArray[0]) {
            case "hello":
               // this is where you decipher private messages posted to the bot.
               // if someone does "/privmsg HGPBot hello" this will reply "Hello!"
               irc.SendMessage(SendType.Message, "HGPBot, "Hello!");
               break;
            default:
               break;
        }
    }
    
    // this method will get all IRC messages
    public static void OnRawMessage(object sender, IrcEventArgs e)
    {
        System.Console.WriteLine("Received: "+e.Data.RawMessage);
    }
