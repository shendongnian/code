    private void CoreWindow_KeyDown(
       Windows.UI.Core.CoreWindow sender, 
       Windows.UI.Core.KeyEventArgs args)
    {
        if (args.VirtualKey == Windows.System.VirtualKey.S)
        {
            //StartMoving(); (or keep moving if already started previously)
        }
    }
    
    private void CoreWindow_KeyUp(
       Windows.UI.Core.CoreWindow sender, 
       Windows.UI.Core.KeyEventArgs args)
    {
        if (args.VirtualKey == Windows.System.VirtualKey.S)
        {
            //StopMoving();
        }
    }
