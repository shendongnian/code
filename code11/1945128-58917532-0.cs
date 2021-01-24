cs
public partial class MainWindow : Window {
	HwndSource source;
	
	const short WM_MOVE = 0x0003;
	
	public MainWindow() {
		InitializeComponent();
		// Loaded event needed to make sure the window handle has been created.
		Loaded += MainWindow_Loaded;
	}
	private void MainWindow_Loaded(object sender, RoutedEventArgs e) {
        // Subscribe to win32 level events
		source = HwndSource.FromHwnd(new WindowInteropHelper(this).Handle);
		source.AddHook(new HwndSourceHook(WndProc));
	}
	private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled) {
		if (msg == WM_MOVE) {
			Console.WriteLine("Window has moved!");
			GetWindowRect(new HandleRef(this, new WindowInteropHelper(this).Handle), out RECT rect);
			Console.WriteLine("New location is " + (rect.Left, rect.Top));
		}
		return IntPtr.Zero;
	}
	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	static extern bool GetWindowRect(HandleRef hWnd, out RECT lpRect);
	[StructLayout(LayoutKind.Sequential)]
	public struct RECT {
		public int Left;
		public int Top;
		public int Right;
		public int Bottom;
	}
}
