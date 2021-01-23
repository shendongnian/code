    namespace System
    {
        internal static class ConsoleEventHooker
        {
            private static bool _initedHooker;
            private static EventHandler _closed; 
            private static EventHandler _shutdown;
            private static ConsoleEventDelegate _d;
    
            public static event EventHandler Closed
            {
                add
                {
                    Init();
                    _closed += value;
                }
                remove { _closed -= value; }
            }
    
            public static event EventHandler Shutdown
            {
                add
                {
                    Init();
                    _shutdown += value;
                }
                remove { _shutdown -= value; }
            }
    
            private static void Init()
            {
                if (_initedHooker) return;
                _initedHooker = true;
                _d = ConsoleEventCallback;
                SetConsoleCtrlHandler(_d, true);
            }
    
            private static bool ConsoleEventCallback(CtrlTypes eventType)
            {
                if (eventType == CtrlTypes.CTRL_CLOSE_EVENT)
                {
                    if(_closed != null) _closed(null,new EventArgs());
                }
    
                if (eventType == CtrlTypes.CTRL_SHUTDOWN_EVENT)
                {
                    if (_shutdown != null) _shutdown(null, new EventArgs());
                }
                return false;
            }
            
            // A delegate type to be used as the handler routine 
            // for SetConsoleCtrlHandler.
            delegate bool ConsoleEventDelegate(CtrlTypes ctrlType);
            
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add);
    
        }
    
        // An enumerated type for the control messages
        // sent to the handler routine.
        public enum CtrlTypes
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT,
            CTRL_CLOSE_EVENT,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT
        }
