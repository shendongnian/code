    internal class MyTabPage : TabPage
    {
        private const int WM_WINDOWPOSCHANGING = 70;
        private const int WM_SETREDRAW = 0xB;
        private const int SWP_NOACTIVATE = 0x0010;
        private const int SWP_NOZORDER = 0x0004;
        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOMOVE = 0x0002;
    
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(HandleRef hWnd, int msg, int wParam, int lParam);
    
        [DllImport("User32.dll", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern bool SetWindowPos(HandleRef hWnd, HandleRef hWndInsertAfter,
        int x, int y, int cx, int cy, int flags);
    
        [StructLayout(LayoutKind.Sequential)]
        private class WINDOWPOS
        {
            public IntPtr hwnd;
            public IntPtr hwndInsertAfter;
            public int x;
            public int y;
            public int cx;
            public int cy;
            public int flags;
        };
    
        private delegate void ResizeChildDelegate(WINDOWPOS wpos);
    
        private void ResizeChild(WINDOWPOS wpos)
        {
            // verify if it's the right instance of MyPanel if needed
            if ((this.Controls.Count == 1) && (this.Controls[0] is Panel))
            {
                Panel child = this.Controls[0] as Panel;
    
                // stop window redraw to avoid flicker
                SendMessage(new HandleRef(child, child.Handle), WM_SETREDRAW, 0, 0);
    
                // start a new stack of SetWindowPos calls
                SetWindowPos(new HandleRef(child, child.Handle), new HandleRef(null, IntPtr.Zero),
                0, 0, wpos.cx, wpos.cy, SWP_NOACTIVATE | SWP_NOZORDER);
    
                // turn window repainting back on 
                SendMessage(new HandleRef(child, child.Handle), WM_SETREDRAW, 1, 0);
    
                // send repaint message to this control and its children
                this.Invalidate(true);
            }
        }
    
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_WINDOWPOSCHANGING)
            {
                WINDOWPOS wpos = new WINDOWPOS();
                Marshal.PtrToStructure(m.LParam, wpos);
    
                Debug.WriteLine("WM_WINDOWPOSCHANGING received by " + this.Name + " flags " + wpos.flags);
    
                if (((wpos.flags & (SWP_NOZORDER | SWP_NOACTIVATE)) == (SWP_NOZORDER | SWP_NOACTIVATE)) &&
                ((wpos.flags & ~(SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER | SWP_NOACTIVATE)) == 0))
                {
                    if ((wpos.cx != this.Width) || (wpos.cy != this.Height))
                    {
                        BeginInvoke(new ResizeChildDelegate(ResizeChild), wpos);
                        return;
                    }
                }
            }
    
            base.WndProc(ref m);
        }
    }
