        #region Interop
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr hdc, PRF_FLAGS drawingOptions);
        const uint WM_PRINT = 0x317;
        [Flags]
        enum PRF_FLAGS : uint
        {
            CHECKVISIBLE = 0x01,
            CHILDREN = 0x02,
            CLIENT = 0x04,
            ERASEBKGND = 0x08,
            NONCLIENT = 0x10,
            OWNED = 0x20
        }
        #endregion
        public static Image CaptureImage(this Control control)
        {
            Image img = new Bitmap(control.Width, control.Height);
            using (Graphics g = Graphics.FromImage(img))
            {
                SendMessage(
                   control.Handle,
                   WM_PRINT,
                   g.GetHdc(),
                   PRF_FLAGS.CLIENT | PRF_FLAGS.NONCLIENT | PRF_FLAGS.ERASEBKGND);
            }
            return img;
        }
