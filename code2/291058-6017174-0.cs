    public class LinkLabelEx : LinkLabel
    {
        private const int WM_SETCURSOR = 0x0020;
        private const int IDC_HAND = 32649;
        [DllImport("user32.dll", CharSet=CharSet.Auto, SetLastError=true)]
        private static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SETCURSOR)
            {
                this.Cursor = new Cursor(LoadCursor(IntPtr.Zero, IDC_HAND));
                return 1;
            }
 
            base.WndProc(m);
        }
    }
