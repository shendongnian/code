	public class ProcessWindows
	{
		List<Window> visibleWindows = new List<Window>();
		List<IntPtr> allWindows = new List<IntPtr>();
		/// <summary>
		/// Contains information about visible windows.
		/// </summary>
		public struct Window
		{
			public IntPtr Handle { get; set; }
			public string Title { get; set; }
		}
		[DllImport("user32.dll")]
		static extern int EnumWindows(EnumWindowsCallback lpEnumFunc, int lParam);
		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		static extern int GetWindowLong(IntPtr hWnd, int nIndex);
		[DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		private static extern void GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
		delegate bool EnumWindowsCallback(IntPtr hwnd, int lParam);
		public ProcessWindows()
		{
			int returnValue = EnumWindows(Callback, 0);
			if (returnValue == 0)
			{
				throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error(), "EnumWindows() failed");
			}
		}
		private bool Callback(IntPtr hwnd, int lParam)
		{
            const int WS_BORDER = 0x800000;
            const int WS_VISIBLE = 0x10000000;
            const int GWL_STYLE = (-16);
            // You'll have to figure out which windows you want here...
			int visibleWindow = WS_BORDER | WS_VISIBLE;
			if ((GetWindowLong(hwnd, GWL_STYLE) & visibleWindow) == visibleWindow)
			{
			    StringBuilder sb = new StringBuilder(100);
			    GetWindowText(hwnd, sb, sb.Capacity);
				this.visibleWindows.Add(new Window()
				{
					Handle = hwnd,
					Title = sb.ToString()
				});
			}
			return true; //continue enumeration
		}
		public ReadOnlyCollection<Window> GetVisibleWindows()
		{
			return this.visibleWindows.AsReadOnly();
		}
	}
    }
