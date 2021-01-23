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
                NewMethod();
            }
    
            unsafe private void NewMethod()
            {
                if (!this.DesignMode)
                    SendMessage(this.Handle, EM_SETWORDBREAKPROC, IntPtr.Zero, Marshal.GetFunctionPointerForDelegate(new EditWordBreakProc(MyEditWordBreakProc)));
            }
    
            [DllImport("User32.DLL")]
            public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
    
            unsafe delegate int EditWordBreakProc(char* lpch, int ichCurrent, int cch, int code);
    
            unsafe int MyEditWordBreakProc(char* lpch, int ichCurrent, int cch, int code)
            {
                const int WB_ISDELIMITER = 2;
                const int WB_CLASSIFY = 3;
                if (code == WB_ISDELIMITER)
                {
                    char ch = *lpch;
                    return ch == '-' ? 0 : 1;
                }
                else if (code == WB_CLASSIFY)
                {
                    char ch = *lpch;
                    var vResult = Char.GetUnicodeCategory(ch);
                    return (int)vResult;
                }
                else
                {
                    var lpch2 = lpch;
                    // in this case, we must find the begining of a word:
                    for (int it = ichCurrent; it < cch; it++)
                    {
                        char ch = *lpch2;
                        if (it + 1 < cch && lpch2[0] == '-' && lpch2[1] != '-')
                            return it;
                        if (lpch2[0] == '\0')
                            return 0;
                        lpch2++;
                    }
                }
    
                return 0;
            }
        }
    }
