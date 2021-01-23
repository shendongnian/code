	class ArbitraryWindow : IWin32Window {
		public ArbitraryWindow(IntPtr handle) { Handle = handle; }
		public IntPtr Handle { get; private set; }
	}
    newForm.Show(new ArbitraryWindow(new IntPtr(Something.Application.Hwnd)));
