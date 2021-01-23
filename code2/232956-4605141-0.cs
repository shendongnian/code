    public void RemoveChatScreen(string clossingScreen)
    {
        MessageBox.Show(GC.GetTotalMemory(true).ToString());
    
        ActiveChatScreens.Remove(clossingScreen);
    
        // all clean up should be performed within Dispose method
        ActiveChatScreens[clossingScreen].Dispose(); 
    
        //GC.Collect();
        //GC.SuppressFinalize(this);
    
        MessageBox.Show(GC.GetTotalMemory(true).ToString());
    }
