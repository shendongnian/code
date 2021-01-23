		private const int SW_SHOWNOACTIVATE = 4;
		private const int HWND_TOPMOST = -1;
		private const uint SWP_NOACTIVATE = 0x0010;
		[System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetWindowPos")]
		private static extern bool SetWindowPos(
			 int hWnd,             // Window handle
			 int hWndInsertAfter,  // Placement-order handle
			 int X,                // Horizontal position
			 int Y,                // Vertical position
			 int cx,               // Width
			 int cy,               // Height
			 uint uFlags);         // Window positioning flags
		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern bool ShowWindow(System.IntPtr hWnd, int nCmdShow);
		public static void ShowInactiveTopmost(System.Windows.Forms.Form frm)
		{
			try
			{
				ShowWindow(frm.Handle, SW_SHOWNOACTIVATE);
				SetWindowPos(frm.Handle.ToInt32(), HWND_TOPMOST,
				frm.Left, frm.Top, frm.Width, frm.Height,
				SWP_NOACTIVATE);
			}
			catch (System.Exception ex)
			{
				// error handling
			}
		}
