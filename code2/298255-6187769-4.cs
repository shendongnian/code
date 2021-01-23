    public void SendMessage( MessageServiceClient proxy, string mail, string authstr )
    {
        MessageServiceClient.SendMessageResponse response = proxy.SendMessage( mail, authstr );
        if( response.Successful )
        {
            MessageBox.Show( "Message Sent" );
        }
        else
        {
            MessageBox.Show( "Message Failed to Send: " + response.Messages.FirstOrDefault() );
        }
    }
