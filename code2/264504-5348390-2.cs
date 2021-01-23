	public static class Utility
	{
		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern IntPtr SendMessage(IntPtr h, int msg, IntPtr lp, IntPtr wp);
		public static void DragMove(IntPtr hwnd)
		{
			const int WM_SYSCOMMAND = 0x112;
			const int WM_LBUTTONUP = 0x202;
			SendMessage(hwnd, WM_SYSCOMMAND, (IntPtr)0xf012, IntPtr.Zero);
			SendMessage(hwnd, WM_LBUTTONUP, IntPtr.Zero, IntPtr.Zero);
		}
	}
