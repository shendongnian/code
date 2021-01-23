    using Microsoft.Win32;
    
    [DllImport("user32.dll")]
    public static extern int FindWindow(string lpClassName,string lpWindowName);
    [DllImport("user32.dll")]
    public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);
    	
    public const int WM_SYSCOMMAND = 0x0112;
    public const int SC_CLOSE = 0xF060;
    
    private void closeWindow()
    {
    	// retrieve the handler of the window  
    	int iHandle = FindWindow("Notepad", "Untitled - Notepad");
    	if (iHandle > 0)
    	{
    		// close the window using API        
    		SendMessage(iHandle, WM_SYSCOMMAND, SC_CLOSE, 0);
    	}  
    }
