    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows;
    
    namespace YourNamespace
    {
        internal static class NativeMethods
        {
            [DllImport("user32.dll")]
            internal static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, ShowDesktop.WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);
    
            [DllImport("user32.dll")]
            internal static extern bool UnhookWinEvent(IntPtr hWinEventHook);
    
            [DllImport("user32.dll")]
            internal static extern int GetClassName(IntPtr hwnd, StringBuilder name, int count);
        }
    
        public static class ShowDesktop
        {
            private const uint WINEVENT_OUTOFCONTEXT = 0u;
            private const uint EVENT_SYSTEM_FOREGROUND = 3u;
    
            private const string WORKERW = "WorkerW";
            private const string PROGMAN = "Progman";
    
            public static void AddHook(Window window)
            {
                if (IsHooked)
                {
                    return;
                }
    
                IsHooked = true;
    
                _delegate = new WinEventDelegate(WinEventHook);
                _hookIntPtr = NativeMethods.SetWinEventHook(EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, _delegate, 0, 0, WINEVENT_OUTOFCONTEXT);
                _window = window;
            }
    
            public static void RemoveHook()
            {
                if (!IsHooked)
                {
                    return;
                }
    
                IsHooked = false;
    
                NativeMethods.UnhookWinEvent(_hookIntPtr.Value);
    
                _delegate = null;
                _hookIntPtr = null;
                _window = null;
            }
    
            private static string GetWindowClass(IntPtr hwnd)
            {
                StringBuilder _sb = new StringBuilder(32);
                NativeMethods.GetClassName(hwnd, _sb, _sb.Capacity);
                return _sb.ToString();
            }
    
            internal delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);
    
            private static void WinEventHook(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
            {
                if (eventType == EVENT_SYSTEM_FOREGROUND)
                {
                    string _class = GetWindowClass(hwnd);
    
                    if (string.Equals(_class, WORKERW, StringComparison.Ordinal) /*|| string.Equals(_class, PROGMAN, StringComparison.Ordinal)*/ )
                    {
                        _window.Topmost = true;
                    }
                    else
                    {
                        _window.Topmost = false;
                    }
                }
            }
    
            public static bool IsHooked { get; private set; } = false;
    
            private static IntPtr? _hookIntPtr { get; set; }
    
            private static WinEventDelegate _delegate { get; set; }
    
            private static Window _window { get; set; }
        }
    }
