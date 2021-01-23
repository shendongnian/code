    Skype skype = new Skype();
    skype.MessageStatus += new _ISkypeEvents_MessageStatusEventHandler(incommingMessage);
   
    private void incommingMessage(ChatMessage msg, TChatMessageStatus status)
    {
        string sender = msg.Sender.Handle; // Skype name of sender!
        string message = msg.Body;         // Message content
        DateTime sendTime = msg.Timestamp; // Time when the sender has sended the message.
        MessageBox.Show(String.Format("Your contact {0} sended you a message at {1}:\n\n{2}", sender, sendTime.ToString("yyyy-MM-ddTHH:mm:ss.fff"), message);
    }
