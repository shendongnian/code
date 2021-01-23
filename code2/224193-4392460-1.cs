    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    class MyTreeView : TreeView {
        protected override void OnHandleCreated(EventArgs e) {
            if (Environment.OSVersion.Version.Major >= 6) {
                SetWindowTheme(this.Handle, "Explorer", null);
            }
            base.OnHandleCreated(e);
        }
        [DllImportAttribute("uxtheme.dll", CharSet = CharSet.Auto)]
        private static extern int SetWindowTheme(IntPtr hWnd, string appname, string idlist);
    }
