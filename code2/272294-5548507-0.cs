	public static class DwmApiInterop
	{
		#region Managed wrapper methods
		public static bool IsCompositionEnabled()
		{
			bool isEnabled = false;
			DwmIsCompositionEnabled(ref isEnabled);
			return isEnabled;
		}
		public static int ExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS margins)
		{
			return DwmExtendFrameIntoClientArea(hWnd, ref margins);
		}
		#endregion
		#region Unmanaged Windows API methods
		[DllImport("dwmapi.dll")]
		private static extern void DwmIsCompositionEnabled(ref bool isEnabled);
		[DllImport("dwmapi.dll")]
		private static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS margins);
		#endregion
	}
