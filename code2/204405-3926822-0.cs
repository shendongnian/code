    internal class MessageSnatcher : NativeWindow
    {
        private readonly Control _control;
        public MessageSnatcher(Control control)
        {
            if (control.Handle != IntPtr.Zero)
                AssignHandle(control.Handle);
            else
                control.HandleCreated += new EventHandler(this.OnHandleCreated);
            control.HandleDestroyed += new EventHandler(this.OnHandleDestroyed);
            _control = control;
        }
        private void OnHandleCreated(object sender, EventArgs e)
        {
            AssignHandle(_control.Handle);
        }
        private void OnHandleDestroyed(object sender, EventArgs e)
        {
            ReleaseHandle();
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
            }
            base.WndProc(ref m);
        }
    }
