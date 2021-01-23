    private void windows_WindowRegistered(int lCookie)
    {
        if (process == null)
            return;  // This wasn't our window for sure
        for (int i = 0; i < windows.Count; i++)
        {
            try
            {
                InternetExplorerLibrary.InternetExplorer ShellWindow = windows.Item(i) as InternetExplorerLibrary.InternetExplorer;
                if (ShellWindow != null)
                {
                    IntPtr tmpHWND = (IntPtr)ShellWindow.HWND;
                    if (tmpHWND == process.MainWindowHandle)
                    {
                        IE = ShellWindow;
                        waitForRegister.Set(); // Signal the constructor that it is safe to go on now.
                        return;
                    }
                }
            }
            catch (InvalidCastException ice)
            {
                //Do nothing. Browser.HWND could not execute for this item.
            }
        }
    }
