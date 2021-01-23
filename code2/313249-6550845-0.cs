    class OvalTextBox : TextBox
    {
        [DllImport("user32.dll")]
        static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);
        [DllImport("gdi32.dll")]
        static extern IntPtr CreateRoundRectRgn(int x1, int y1, int x2, int y2, int cx, int cy);
        public OvalTextBox()
        {
            base.BorderStyle = System.Windows.Forms.BorderStyle.None;
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SetWindowRgn(this.Handle, CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20), true);
        }
    }
