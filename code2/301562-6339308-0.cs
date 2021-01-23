	public class Win32Window : IWin32Window
	{
		public Win32Window(IntPtr val)
		{
			_handle = val;
		}
		readonly IntPtr _handle;
		public IntPtr Handle
		{
			get { return _handle; }
		}
	}
