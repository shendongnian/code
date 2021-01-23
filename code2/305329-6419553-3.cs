    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace q6359774
    {
        class MyRichTextBox : RichTextBox
        {
            const int EM_SETWORDBREAKPROC = 0x00D0;
            const int EM_GETWORDBREAKPROC = 0x00D1;
    
            protected override void OnHandleCreated(EventArgs e)
            {
                base.OnHandleCreated(e);
                this.Text = "abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz";
                if (!this.DesignMode)
                    SendMessage(this.Handle, EM_SETWORDBREAKPROC, IntPtr.Zero, Marshal.GetFunctionPointerForDelegate(new EditWordBreakProc(MyEditWordBreakProc)));
            }
    
            [DllImport("User32.DLL")]
            public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
    
            delegate int EditWordBreakProc(string lpch, int ichCurrent, int cch, int code);
    
            int MyEditWordBreakProc(string lpch, int ichCurrent, int cch, int code)
            {
                const int WB_ISDELIMITER = 2;
                const int WB_CLASSIFY = 3;
                if (code == WB_ISDELIMITER)
                {
                    if (lpch.Length == 0 || lpch == null) return 0;
                    char ch = lpch[ichCurrent];
                    return ch == '-' ? 0 : 1;
                }
                else if (code == WB_CLASSIFY)
                {
                    if (lpch.Length == 0 || lpch == null) return 0;
                    char ch = lpch[ichCurrent];
                    var vResult = Char.GetUnicodeCategory(ch);
                    return (int)vResult;
                }
                else
                {
                    if (lpch.Length == 0 || lpch == null) return 0;
                    for (int it = ichCurrent; it < lpch.Length; it++)
                    {
                        char ch = lpch[it];
                        if (ch != '-') return it;
                    }
                }
    
                return 0;
            }
        }
    }
