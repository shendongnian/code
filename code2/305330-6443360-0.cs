    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace MyNameSpace
    {
        public class SpaceBreakingRichTextBox : RichTextBox
        {
            const int EM_SETWORDBREAKPROC = 0x00D0;
            const int EM_GETWORDBREAKPROC = 0x00D1;
    
            protected override void OnHandleCreated(EventArgs e)
            {
                base.OnHandleCreated(e);
                AddDelegate();
            }
    
            [DllImport("User32.DLL")]
            public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
    
            unsafe delegate int EditWordBreakProc(char* lpch, int ichCurrent, int cch, int code);
            EditWordBreakProc myDelegate;
    
            unsafe private void AddDelegate()
            {
                if (!this.DesignMode)
                {
                    myDelegate = new EditWordBreakProc(MyEditWordBreakProc);
                    SendMessage(this.Handle, EM_SETWORDBREAKPROC, IntPtr.Zero, Marshal.GetFunctionPointerForDelegate(myDelegate));
                }
            }
    
            unsafe int MyEditWordBreakProc(char* lpch, int ichCurrent, int cch, int code)
            {
                const int WB_ISDELIMITER = 2;
                const int WB_CLASSIFY = 3;
                const int WB_MOVEWORDLEFT = 4;
                const int WB_MOVEWORDRIGHT = 5;
    
                const int WB_LEFTBREAK = 6;
                const int WB_RIGHTBREAK = 7;
    
                const int WB_LEFT = 0;
                const int WB_RIGHT = 1;
    
                if (code == WB_ISDELIMITER)
                {
                    char ch = *lpch;
                    return ch == ' ' ? 1 : 0;
                }
                else if (code == WB_CLASSIFY)
                {
                    char ch = *lpch;
                    var vResult = Char.GetUnicodeCategory(ch);
                    return (int)vResult;
                }
                else if (code == WB_LEFTBREAK)
                {
                    for (int it = ichCurrent; it >= 0; it--)
                    {
                        if (lpch[it] == ' '/* && lpch2[1] != ' '*/)
                        {
                            if (it > 0 && lpch[it - 1] != ' ')
                                return it;
                        }
                    }
                }
                else if (code == WB_RIGHT)
                {
                    for (int it = ichCurrent; ; it++)
                    {
                        if (lpch[it] != ' ')
                            return it;
                    }
                }
                else
                {
                     // There might be more cases to handle (see constants)
                }
                return 0;
            }
        }
    }
