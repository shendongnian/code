    public class FocusFormWrapper
    {
        #region DllImport
        public const int GWL_WNDPROC = (-4);
        public const UInt32 WM_CLOSE = 0x0010;
        public const UInt32 WM_PARENTNOTIFY = 0x0210; 
        public delegate IntPtr WndProcDelegate(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindow(IntPtr hWnd);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr newWndProc);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string _ClassName, string _WindowName);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        #endregion DllImport
        private Form myForm = null;
        private IntPtr hWndTarget = IntPtr.Zero;
        private IntPtr oldWndProc = IntPtr.Zero;
        private WndProcDelegate newWndProc;
        private FocusFormWrapper()
        {
        }
        public FocusFormWrapper(Form sourceForm)
        {
            if (sourceForm == null)
                throw new ArgumentNullException("sourceForm");
            if (!IsWindow(sourceForm.Handle))
                throw new ArgumentException("sourceForm IsWindow failed");
            myForm = sourceForm;
            hWndTarget = myForm.Handle;
            AddSubclass();
        }
        ~FocusFormWrapper()
        {
            RemoveSubclass();
            myForm = null;
            newWndProc = null;
        }
        private int AddSubclass()
        {
            int result = -1;
            if (myForm != null && newWndProc == null)
            {
                newWndProc = new WndProcDelegate(NewWndProc);
                oldWndProc = GetWindowLong(hWndTarget, GWL_WNDPROC);
                result = SetWindowLong(hWndTarget, GWL_WNDPROC, Marshal.GetFunctionPointerForDelegate(newWndProc));
            }
            return result;
        }
        public int RemoveSubclass()
        {
            int result = -1;
            if (myForm != null && newWndProc != null)
            {
                result = SetWindowLong(hWndTarget, GWL_WNDPROC, oldWndProc);
                newWndProc = null;
            }
            return result;
        }
        
        public IntPtr NewWndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            try
            {
                if (msg == WM_PARENTNOTIFY && !myForm.Focused)
                {
                    // Make this form auto-grab the focus when menu/controls are clicked 
                    myForm.Activate();
                }
                if (msg == WM_CLOSE)
                {
                    RemoveSubclass();
                }
            }
            catch
            {
            }
            return CallWindowProc(oldWndProc, hWnd, msg, wParam, lParam);
        }
    }
