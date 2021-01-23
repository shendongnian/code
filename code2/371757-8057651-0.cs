    private static IntPtr SetHook(LowLevelMouseProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                IntPtr ptr = GetModuleHandle(curModule.ModuleName);
                return SetWindowsHookEx(WH_MOUSE, proc,
                    IntPtr.Zero, (uint)AppDomain.GetCurrentThreadId());
            }
        }
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 &&  MouseMessages.WM_LBUTTONDOWN == (MouseMessages)wParam)
            { 
                MOUSEHOOKSTRUCT msg = (MOUSEHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MOUSEHOOKSTRUCT));
                PictureBox control = Control.FromHandle(msg.hwnd) as PictureBox;
                if (control != null)
                {
                    PreviewForm.pbox_MouseClick(control, new MouseEventArgs(MouseButtons.Left, 2, msg.pt.x, msg.pt.y, 0));
                }                
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
