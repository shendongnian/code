		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
		public static void StartDrag(Window window)
		{
			WindowInteropHelper helper = new WindowInteropHelper(window);
			SendMessage(helper.Handle, 161, 2, 0);
		}
