      internal class MyNativeMDIclient : NativeWindow
        {
            private MdiClient mdiClient;
    
            public MyNativeMDIclient(MdiClient parent)
            {
                mdiClient = parent;
                ReleaseHandle();
                AssignHandle(mdiClient.Handle);            
            }
            internal void OnHandleDestroyed(object sender, EventArgs e)
            {
                ReleaseHandle();
            }
            private const int SB_BOTH = 3;
            [DllImport("user32.dll")]
            private static extern int ShowScrollBar(IntPtr hWnd, int wBar, int bShow);
            protected override void WndProc(ref Message m)
            {
                ShowScrollBar(m.HWnd, SB_BOTH, 0 /*false*/);
                base.WndProc(ref m);
            }
        }
