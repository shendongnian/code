    public class Form1
    {
        static int hHook = 0;
        public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        HookProc MouseHookProcedure;
        private void ActivateMouseHook_Click(object sender, System.EventArgs e)
        {
            if(hHook == 0)
            {
                MouseHookProcedure = new HookProc(Form1.MouseHookProc);
                hHook = SetWindowsHookEx(WH_MOUSE, 
		                         MouseHookProcedure,
                                 (IntPtr) 0,
                                 AppDomain.GetCurrentThreadId());
            }
        }
    }
