    using System.Windows.Interop;
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			this.SourceInitialized += new EventHandler(OnSourceInitialized);
		}
		private void OnSourceInitialized(object sender, EventArgs e)
		{
			HwndSource source = (HwndSource)PresentationSource.FromVisual(this);
			source.AddHook(new HwndSourceHook(HandleMessages));
		}
		private IntPtr HandleMessages(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
		{
			// 0x0112 == WM_SYSCOMMAND, 'Window' command message.
			// 0xF020 == SC_MINIMIZE, command to minimize the window.
			if (msg == 0x0112 && ((int)wParam & 0xFFF0) == 0xF020)
			{
				// Cancel the minimize.
				handled = true;
			}
			return IntPtr.Zero;
		}
	}
