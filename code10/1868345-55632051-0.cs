	public class StopController : Form, IMessageFilter
    {
        //logger
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static private CancellationTokenSource cancellationTokenSource;
        public StopController(CancellationTokenSource cancellationTokenSource)
        {
            StopController.cancellationTokenSource = cancellationTokenSource;
            System.Windows.Forms.Application.AddMessageFilter(this);
            SetConsoleCtrlHandler(new HandlerRoutine(ConsoleCtrlCheck), true);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 16)
            {
                log.Warn("Receiveing WF_Close event. Cancel was fired.");
                cancellationTokenSource.Cancel();
            }
            return true;
        }
        public static void Activate(CancellationTokenSource cancellationTokenSource)
        {            
            Task.Run(() => Application.Run(new StopController(cancellationTokenSource)));
        }
        #region unmanaged
        //must be static.
        private static bool ConsoleCtrlCheck(CtrlTypes ctrlType)
        {
            // Put your own handler here
            switch (ctrlType)
            {
                case CtrlTypes.CTRL_C_EVENT:
                    log.Warn("CTRL+C received!. Cancel was fired.");
                    cancellationTokenSource.Cancel();
                    break;
                case CtrlTypes.CTRL_BREAK_EVENT:
                    log.Warn("CTRL+BREAK received!. Cancel was fired.");
                    cancellationTokenSource.Cancel();
                    break;
                case CtrlTypes.CTRL_CLOSE_EVENT:
                    log.Warn("Program being closed!. Cancel was fired.");
                    cancellationTokenSource.Cancel();
                    break;
                case CtrlTypes.CTRL_LOGOFF_EVENT:
                case CtrlTypes.CTRL_SHUTDOWN_EVENT:
                    log.Warn("User is logging off!. Cancel was fired.");
                    cancellationTokenSource.Cancel();
                    break;
                default:
                    log.Warn($"unknow type {ctrlType}");
                    break;
            }
            return true;
        }
        // Declare the SetConsoleCtrlHandler function
        // as external and receiving a delegate.
        [DllImport("Kernel32")]
        public static extern bool SetConsoleCtrlHandler(HandlerRoutine Handler, bool Add);
        // A delegate type to be used as the handler routine
        // for SetConsoleCtrlHandler.
        public delegate bool HandlerRoutine(CtrlTypes CtrlType);
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
        #endregion
    }
