    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    class SimpleProgressBar : ProgressBar {
        protected override void OnHandleCreated(EventArgs e) {
            base.OnHandleCreated(e);
            if (Environment.OSVersion.Version.Major >= 6) {
                SetWindowTheme(this.Handle, "", "");
            }
        }
        [DllImport("uxtheme.dll")]
        private static extern int SetWindowTheme(IntPtr hWnd, string appname, string idlist);
    }
