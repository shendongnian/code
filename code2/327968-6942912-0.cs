	[DllImport("user32.dll")]
	static extern IntPtr GetForegroundWindow();
	[DllImport("user32.dll", SetLastError = true)]
	static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
	[StructLayout(LayoutKind.Sequential)]
	struct RECT
	{
		public int Left;
		public int Top;
		public int Width;
		public int Height;
	}
	static bool IsBigWindowRunning()
	{
		foreach (Process proc in Process.GetProcesses())
		{
			RECT rect;
			var success = GetWindowRect(proc.MainWindowHandle, out rect);
			if(success && (r.Left + r.Width) >= Screen.PrimaryScreen.WorkingArea.Width)
			{
				return true;
			}
		}
		return false;
	}
