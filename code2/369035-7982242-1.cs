    public void UpdateStatus(string message, MessageType type)
    {
       statusText.Text = message;
    
       switch (type)
       {
           case MessageType.Error:
               statusText.ForeColor = Color.Red;
               break;
    
          case MessageType.Success:
               statusText.ForeColor = Color.Green;
               break;
       }
    }
