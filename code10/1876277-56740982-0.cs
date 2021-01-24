    public delegate void MouseDownEventHandler(object sender, MouseDownEventArgs e);
    public class WndProcTest
    {
        [DllImport("coredll.dll", SetLastError = true)]
        private static extern IntPtr GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("coredll.dll", SetLastError = true)]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, WndProcDelegate dwNewLong);
        [DllImport("coredll.dll", SetLastError = true)]
        static extern IntPtr CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("coredll.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowsName);
        private delegate IntPtr WndProcDelegate(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
		
        public event MouseDownEventHandler mouseDownTriggered;
        private WndProcDelegate _newproc;
        private int result;
        private IntPtr _oldproc = IntPtr.Zero;
        internal static IntPtr _hwnd = IntPtr.Zero;
		
		// Mouse down message value
        const int WM_LBUTTONDOWN = 0x0201;
		// Get window/control handle using name
        public WndProcTest(string windowsName)
        {
            _hwnd = FindWindow(null, windowsName);
        }
		// Initialization to allow a control to receive message
        public void InitWndProcModification()
        {
            _newproc = new WndProcDelegate(MyWndProc);
            _oldproc = GetWindowLong(_hwnd, -4);
            result = SetWindowLong(_hwnd, -4, Marshal.GetFunctionPointerForDelegate(_newproc));
        }
		
		// Intercept the message
        private IntPtr MyWndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            switch (msg)
            {
                case WM_LBUTTONDOWN:
                    MouseDownEventArgs mouseDownEventArgs = new FingerPrintSensorEventArgs();
                    OnMouseDownTriggered(mouseDownEventArgs);
                    break;
                default:
                    break;
            }
            return CallWindowProc(_oldproc, hWnd, msg, wParam, lParam);
        }
        public void RemoveWndProcModification(IntPtr currentHandle)
        {
            result = SetWindowLong(currentHandle, -4, _oldproc);
            _newproc = null;
            _oldproc = IntPtr.Zero;
            _hwnd = IntPtr.Zero;
        }
		// Fire the event
        protected virtual void OnMouseDownTriggered(MouseDownEventArgs e)
        {
            if (mouseDownTriggered != null)
            {
                mouseDownTriggered(this, e);
            }
        }
    }
	// Event arguments, to pass the X & Y location?
    public class MouseDownEventArgs : EventArgs
    {
    }
    // To use the class above 
    WndProcTest wp = new WndProcTest("Form1"); 
    wp.InitWndProcModification(); 
    wp.mouseDownTriggered += ReceivedMsg;
    public void ReceivedMsg(Object sender, MouseDownEventArgs e) { 	 }
