    void Click()
    {
        /// Calls the function MessageToSend without options
        SendMessage("MessageToSend", SendMessageOptions.DontRequireReceiver);
    }
    
    // Every script attached to the game object
    // that has a MessageToSend function will be called.
    void MessageToSend()
    {
        Debug.Log(transform.name & " got the message");
    }
