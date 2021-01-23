    public override NSApplicationTerminateReply ApplitionShouldTerminate(NSApplication sender) 
    {
        mainWindowController.Window.Close();
        return NSApplicationTerminateReply.Now;
    }
    
    public override bool ApplicationShouldTerminateAfterLastWindowClosed(NSApplication sender)
    {
        return true;
    }
