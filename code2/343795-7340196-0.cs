    IXDListener listener = XDListener.CreateListener(
                                          XDTransportMode.WindowsMessaging);
    listener.MessageReceived+=XDMessageHandler(listener_MessageReceived);
    listener.RegisterChannel("commands");
     // process the message
    private void listener_MessageReceived(object sender, XDMessageEventArgs e)
    {
        // e.DataGram.Message is the message
        // e.DataGram.Channel is the channel name
        switch(e.DataGram.Message)
        {
            case "focus":
            // check requires invoke
                this.focus();
                break;
            case "close"
                this.close();
                break;
        }
    }
