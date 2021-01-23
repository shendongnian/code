    void UpdateMessage (string message)
    {
        if(InvokeRequired)
        {
            Invoke((Action)()=>UpdateMessage(message));
            return;
        }
        
        txtMessage.Text = message;
    }
