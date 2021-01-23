    public class WindowBase : Window
    {
        private bool hasFadeCompleted = false;
        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.hasFadeCompleted)
            {
                base.OnClosing(e);
                return;
            }
            e.Cancel = true;
            var hWnd = new WindowInteropHelper(this).Handle;
            User32.AnimateWindow(hWnd, 1, AnimateWindowFlags.AW_BLEND | AnimateWindowFlags.AW_HIDE);
            Task.Factory.StartNew(() =>
            {
                this.Dispatcher.Invoke(new Action(() =>
                {
                    this.hasFadeCompleted = true;
                    this.Close();
                }), DispatcherPriority.Normal);
            });
        }
    }
    public static class User32
    {
        [DllImport("user32.dll")]
        public static extern bool AnimateWindow(IntPtr hWnd, int time, uint flags);
    }
    public static class AnimateWindowFlags
    {
        public const uint AW_HOR_POSITIVE = 0x00000001;
        public const uint AW_HOR_NEGATIVE = 0x00000002;
        public const uint AW_VER_POSITIVE = 0x00000004;
        public const uint AW_VER_NEGATIVE = 0x00000008;
        public const uint AW_CENTER = 0x00000010;
        public const uint AW_HIDE = 0x00010000;
        public const uint AW_ACTIVATE = 0x00020000;
        public const uint AW_SLIDE = 0x00040000;
        public const uint AW_BLEND = 0x00080000;
    }
    
