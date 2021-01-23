    public class GetTextTestClass{
    
    	[System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
    	public static extern int RegisterWindowMessage(string lpString);
    
    	[System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
    	public static extern bool SendMessage(IntPtr hWnd, uint Msg, int wParam, StringBuilder lParam);
    
    	[System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
    	public static extern IntPtr SendMessage(int hWnd, int Msg, int wparam, int lparam);
    
    	const int WM_GETTEXT       = 0x000D;
    	const int WM_GETTEXTLENGTH = 0x000E;
    
    	public string GetControlText(IntPtr hWnd){
    
    		// Get the titleSize of the string required to hold the window title. 
    		Int32 titleSize = SendMessage((int)hWnd, WM_GETTEXTLENGTH, 0, 0).ToInt32();
    
    		// If titleSize is 0, there is no title so return an empty string (or null)
    		if (titleSize == 0)
    			return String.Empty;
    		
    		StringBuilder title = new StringBuilder(titleSize + 1);
    
    		SendMessage(hWnd, (int)WM_GETTEXT, title.Capacity, title);
    
    		return title.ToString();
    	}
    }
