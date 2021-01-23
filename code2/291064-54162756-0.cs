    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    public class MyLinkLabel : LinkLabel
    {
        const int IDC_HAND = 32649;
        const int WM_SETCURSOR = 0x0020;
        const int HTCLIENT = 1;
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        static extern IntPtr SetCursor(HandleRef hcursor);
        static readonly Cursor SystemHandCursor = 
            new Cursor(LoadCursor(IntPtr.Zero, IDC_HAND));
        protected override void WndProc(ref Message msg)
        {
            if (msg.Msg == WM_SETCURSOR)
                WmSetCursor(ref msg);
            else
                base.WndProc(ref msg);
        }
        void WmSetCursor(ref Message m)
        {
            if (m.WParam == (IsHandleCreated ? Handle : IntPtr.Zero) &&
               (unchecked((int)(long)m.LParam) & 0xffff) == HTCLIENT) {
                if (OverrideCursor != null) {
                    if (OverrideCursor == Cursors.Hand)
                        SetCursor(new HandleRef(SystemHandCursor, SystemHandCursor.Handle));
                    else
                        SetCursor(new HandleRef(OverrideCursor, OverrideCursor.Handle));
                }
                else {
                    SetCursor(new HandleRef(Cursor, Cursor.Handle));
                }
            }
            else {
                DefWndProc(ref m);
            }
        }
    }
