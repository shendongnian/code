    using System;
    using System.Runtime.InteropServices;
    class WinApi
    { 
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
    
        public const           UInt32 WmChar  =         0x102;
        public static readonly IntPtr VkSpace = (IntPtr)0x20;
    }
