    using System;
    using System.Text;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    
    static class Utils {
        public static void MoveHelpWindow(Rectangle rc) {
            EnumThreadWndProc callback = (hWnd, lp) => {
                // Check if this is the help window
                StringBuilder sb = new StringBuilder(260);
                GetClassName(hWnd, sb, sb.Capacity);
                if (sb.ToString() != "HH Parent") return true;
                RECT dlgRect = new RECT { Left = rc.Left, Top = rc.Top, Right = rc.Right, Bottom = rc.Bottom };
                MoveWindow(hWnd, rc.Left, rc.Top, rc.Width, rc.Height, false);
                return false;
            };
            foreach (ProcessThread pth in Process.GetCurrentProcess().Threads) {
                EnumThreadWindows(pth.Id, callback, IntPtr.Zero);
            }
        }
        // P/Invoke declarations
        private delegate bool EnumThreadWndProc(IntPtr hWnd, IntPtr lp);
        [DllImport("user32.dll")]
        private static extern bool EnumThreadWindows(int tid, EnumThreadWndProc callback, IntPtr lp);
        [DllImport("user32.dll")]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder buffer, int buflen);
        [DllImport("user32.dll")]
        private static extern bool MoveWindow(IntPtr hWnd, int x, int y, int w, int h, bool repaint);
        private struct RECT { public int Left; public int Top; public int Right; public int Bottom; }
    }
