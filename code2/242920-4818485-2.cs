    public class MessageLoop
    {
        public delegate void HandleProvider(IntPtr handle);
        private Object _Lock;
        private ApplicationContext _ApplicationContext;
        private CustomMessageFilter _MessageFilter;
        private HandleProvider _ResourceCleaner;
        private IntPtr _WindowHandle;
        private ManualResetEvent _Completion;
        private bool _Disposed;
        public MessageLoop(HandleProvider provideHandle, MessageFilter messageFilter,
            HandleProvider cleanResource)
        {
            _Lock = new Object();
            _ResourceCleaner = cleanResource;
            _Completion = new ManualResetEvent(false);
            _Disposed = false;
            Thread thread = new Thread(delegate()
            {
                _ApplicationContext = new ApplicationContext();
                Form form = new Form();
                provideHandle(form.Handle);
                _WindowHandle = form.Handle;
                _MessageFilter = new CustomMessageFilter(messageFilter);
                Application.AddMessageFilter(_MessageFilter);
                _Completion.Set();
                AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
                Application.Run(_ApplicationContext);
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;
            thread.Start();
        }
        void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            lock (_Lock)
            {
                if (_Disposed)
                    return;
                Application.RemoveMessageFilter(_MessageFilter);
                _ResourceCleaner(_WindowHandle);
                _ApplicationContext.ExitThread();
                _Disposed = true;
            }
        }
        public void ExitLoop()
        {
            lock (_Lock)
            {
                if (_Disposed)
                    return;
                _Completion.WaitOne();
                Application.RemoveMessageFilter(_MessageFilter);
                _ResourceCleaner(_WindowHandle);
                _ApplicationContext.ExitThread();
                _Disposed = true;
            }
        }
    }
    public delegate bool MessageFilter(ref Message m);
    internal class CustomMessageFilter : IMessageFilter
    {
        private MessageFilter _Filter;
        public CustomMessageFilter(MessageFilter filter)
        {
            _Filter = filter;
        }
        #region IMessageFilter Members
        public bool PreFilterMessage(ref Message m)
        {
            return _Filter(ref m);
        }
        #endregion // IMessageFilter Members
    }
