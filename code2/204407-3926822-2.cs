    internal class MessageSnatcher : NativeWindow
    {
        public event EventHandler LeftMouseClickOccured = delegate{};
        private const int WM_LBUTTONDOWN = 0x201;
        private const int WM_PARENTNOTIFY = 0x210;
        private readonly Control _control;
        public MessageSnatcher(Control control)
        {
            if (control.Handle != IntPtr.Zero)
                AssignHandle(control.Handle);
            else
                control.HandleCreated += OnHandleCreated;
            control.HandleDestroyed += OnHandleDestroyed;
            _control = control;
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_PARENTNOTIFY)
            {
                if (m.WParam.ToInt64() == WM_LBUTTONDOWN)
                    LeftMouseClickOccured(this, EventArgs.Empty);
            }
            base.WndProc(ref m);
        }
        private void OnHandleCreated(object sender, EventArgs e)
        {
            AssignHandle(_control.Handle);
        }
        private void OnHandleDestroyed(object sender, EventArgs e)
        {
            ReleaseHandle();
        }
    }
