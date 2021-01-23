    public abstract partial class SetWindowLongForm : Form
    {
        [DllImport("user32.dll")]
        private static extern IntPtr RealChildWindowFromPoint(IntPtr hwndParent, POINT ptParentClientCoords);
        [DllImport("user32.dll")]
        private static extern IntPtr ChildWindowFromPoint(IntPtr hWndParent, POINT Point);
        [DllImport("User32.Dll", EntryPoint = "PostMessageA")]
        public static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);
        [DllImport("user32")]
        private static extern IntPtr SetWindowLong(IntPtr hWnd, int nIndex, WindowProcedure newProc);
        [DllImport("user32.dll")]
        private static extern IntPtr DefWindowProc(IntPtr hWnd, int uMsg, int wParam, int lParam);
        [DllImport("user32")]
        private static extern IntPtr CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        private delegate IntPtr WindowProcedure(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int X;
            public int Y;
            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
            public POINT(System.Drawing.Point pt) : this(pt.X, pt.Y) { }
            public static implicit operator System.Drawing.Point(POINT p)
            {
                return new System.Drawing.Point(p.X, p.Y);
            }
            public static implicit operator POINT(System.Drawing.Point p)
            {
                return new POINT(p.X, p.Y);
            }
        }
        private WindowProcedure newWindowProcedure = null;
        private IntPtr oldWindowProcedure = IntPtr.Zero;
        private IntPtr HookedWindowHandle = IntPtr.Zero;
        private const int GWL_WNDPROC = -4;
        private Timer SetWindowLongTimer;
        protected abstract void onShockWaveClick();
        protected abstract void onShockWaveBorderLineMouseMove(int x, int y);
        public SetWindowLongForm()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetWindowLongTimer = new Timer();
            SetWindowLongTimer.Interval = 1000;
            SetWindowLongTimer.Tick += new EventHandler(SetWindowLongTimer_Tick);
            SetWindowLongTimer.Start();
        }
        private void SetWindowLongTimer_Tick(object sender, EventArgs e)
        {
            SetWindowLongTimer.Stop();
            SetWindowLongTimer.Tick -= new EventHandler(SetWindowLongTimer_Tick);
            try
            {
                Control shockerHandle = Controls.OfType<AxShockwaveFlashObjects.AxShockwaveFlash>().FirstOrDefault();
                if (shockerHandle == null) return;
                ChangeShockWaveWindowProcedure(shockerHandle.Handle);
            }
            catch { }
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            RevertShockWaveWindowProcedure();
        }
        private void ChangeShockWaveWindowProcedure(IntPtr theHandle)
        {
            if (theHandle != IntPtr.Zero)
            {
                HookedWindowHandle = theHandle;
                newWindowProcedure = new WindowProcedure(newWindowProc);
                oldWindowProcedure = SetWindowLong(HookedWindowHandle, GWL_WNDPROC, newWindowProcedure);
            }
        }
        private void RevertShockWaveWindowProcedure()
        {
            if (HookedWindowHandle != IntPtr.Zero)
            {
                SetWindowLong(HookedWindowHandle, GWL_WNDPROC, oldWindowProcedure);
                HookedWindowHandle = IntPtr.Zero;
            }
        }
        private IntPtr newWindowProc(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam)
        {
            const int WM_MOUSEMOVE = 0x0200;
            const int WM_LBUTTONDOWN = 0x0201;
            switch (Msg)
            {
                case WM_MOUSEMOVE:
                    {
                        //Control ctrlTmp = Control.FromHandle(hWnd);
                        int x = lParam.ToInt32() & 0xffff;
                        int y = lParam.ToInt32() >> 16;
                        onShockWaveBorderLineMouseMove(x, y);
                        break;
                    }
                case WM_LBUTTONDOWN:
                    ReleaseCapture();
                    Point pt = new Point(MousePosition.X, MousePosition.Y);
                    Control ctrl = Control.FromHandle(hWnd); // Controls.OfType<AxShockwaveFlashObjects.AxShockwaveFlash>().FirstOrDefault();
                    pt = ctrl.PointToClient(pt);
                    IntPtr ax = ctrl.Handle;
                    Rectangle r = new Rectangle(0, 0, ctrl.Width, ctrl.Height);
                    IntPtr isTHis = ChildWindowFromPoint(Handle, new POINT(pt)); //where was the mouse pressed
                    if (r.Contains(pt))
                    {
                        onShockWaveClick();
                    }
                    ReleaseCapture();
                    break;
            }
            return CallWindowProc(oldWindowProcedure, hWnd, Msg, wParam, lParam);
        }
        protected override void WndProc(ref Message m)
        {
            //if (m.Msg == 528)
            //{
            //    IntPtr lbutDown = new IntPtr(0x0201);
            //    if (m.WParam == lbutDown)
            //    {
            //        Point pt = new Point(MousePosition.X, MousePosition.Y);
            //        pt = axShockwaveFlash1.PointToClient(pt);
            //        IntPtr ax = axShockwaveFlash1.Handle;
            //        Rectangle r = new Rectangle(0, 0, axShockwaveFlash1.Width, axShockwaveFlash1.Height);
            //        IntPtr isTHis = ChildWindowFromPoint(Handle, new POINT(pt));
            //        if (r.Contains(pt))
            //        {
            //            int k = 90;
            //            k += 90;
            //        }
            //    }
            //}
            base.WndProc(ref m);
        }
    }
