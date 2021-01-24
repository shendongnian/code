    namespace Example
    {
        public partial class WPFWindow : Window
        {
            private UsbEventRegistration _usbEventRegistration;
            public WPFWindow()
            {
                InitializeComponent();
            }
            protected override void OnSourceInitialized(EventArgs e)
            {
                base.OnSourceInitialized(e);
                
                // IMO this should be abstracted away from the code-behind.
                var windowSource = (HwndSource)PresentationSource.FromVisual(this);
                _usbEventRegistration = new UsbEventRegistration(windowSource.Handle);
               // This will allow your window to receive USB events.
               _usbEventRegistration.Register();
               // This hook is what we were aiming for. All Windows events are listened to here. We can inject our own listeners.
               windowSource.AddHook(WndProc);
            }
            private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
            {
                // Here's where the help ends. Do what you need here.
                // Get additional info from http://www.pinvoke.net/
                // USB event message is msg == 0x0219 (WM_DEVICECHANGE).
                // USB event plugin is wParam == 0x8000 (DBT_DEVICEARRIVAL).
                // USB event unplug is wParam == 0x8004 (DBT_DEVICEREMOVECOMPLETE).
                // Your device info is in lParam. Filter that.
                // You need to convert wParam/lParam to Int32 using Marshal.
                return IntPtr.Zero;
            }
        }
    }
