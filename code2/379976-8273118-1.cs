	//This is a replacement for Cursor.Position in WinForms
	[System.Runtime.InteropServices.DllImport("user32.dll")]
	static extern bool SetCursorPos(int x, int y);
	[System.Runtime.InteropServices.DllImport("user32.dll")]
	public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
	public const int MOUSEEVENTF_LEFTDOWN = 0x02;
	public const int MOUSEEVENTF_LEFTUP = 0x04;
	//This simulates a left mouse click
	public static void LeftMouseClick(int xpos, int ypos)
	{
		SetCursorPos(xpos, ypos);
		mouse_event(MOUSEEVENTF_LEFTDOWN, xpos, ypos, 0, 0);
		mouse_event(MOUSEEVENTF_LEFTUP, xpos, ypos, 0, 0);
	}
