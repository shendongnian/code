    public  class Program
    {
        delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);
        [DllImport("user32.dll")]
        static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);
        private const uint WINEVENT_OUTOFCONTEXT = 0;
        private const uint EVENT_SYSTEM_FOREGROUND = 3;
        static void Main(string[] args)
        {
            WinEventDelegate dele = new WinEventDelegate(WinEventProc);
            IntPtr m_hhook = SetWinEventHook(EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, dele, 0, 0, WINEVENT_OUTOFCONTEXT);
            EventLoop.Run();
          //  Console.ReadKey();
        }
        static void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            Console.WriteLine(hwnd.ToString());
        }
    }
       public static class EventLoop
        {
            public static void Run()
            {
                MSG msg;
 
                while (true)
                {
       
                    if (PeekMessage(out msg, IntPtr.Zero, 0, 0, PM_REMOVE))
                    {
                        if (msg.Message == WM_QUIT)
                            break;
                        TranslateMessage(ref msg);
                        DispatchMessage(ref msg);
                    }
                }
            }
            [StructLayout(LayoutKind.Sequential)]
            private struct MSG
            {
                public IntPtr Hwnd;
                public uint Message;
                public IntPtr WParam;
                public IntPtr LParam;
                public uint Time;
            }
            const uint PM_NOREMOVE = 0;
            const uint PM_REMOVE = 1;
            const uint WM_QUIT = 0x0012;
            [DllImport("user32.dll")]
            private static extern bool PeekMessage(out MSG lpMsg, IntPtr hwnd, uint wMsgFilterMin, uint wMsgFilterMax, uint wRemoveMsg);
            [DllImport("user32.dll")]
            private static extern bool TranslateMessage(ref MSG lpMsg);
            [DllImport("user32.dll")]
            private static extern IntPtr DispatchMessage(ref MSG lpMsg);
        }
    }e
