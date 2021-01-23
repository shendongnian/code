    public void RemoveChatScreen(string closingScreen)
    {
        MessageBox.Show(GC.GetTotalMemory(true).ToString());
        
        IChatViewModel chatWindow = ActiveChatScreens[closingScreen]
        // remove from collection - GC may pass over object referenced in collection
        // until next pass, or 3rd pass...who knows, it's indeterminate
        ActiveChatScreens.Remove(closingScreen);
    
        // all clean up should be performed within Dispose method
        chatWindow.Dispose(); 
    
        //GC.Collect();
        //GC.SuppressFinalize(this);
    
        MessageBox.Show(GC.GetTotalMemory(true).ToString());
    }
