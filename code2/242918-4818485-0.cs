    public class MessageLoop
    {
        public delegate void HandleProvider(IntPtr handle);
        private ApplicationContext _ApplicationContext;
        private CustomMessageFilter _MessageFilter;
        private HandleProvider _ResourceCleaner;
        private IntPtr _WindowHandle;
        private ManualResetEvent _Completion;
        private bool _Disposed;
        public MessageLoop(HandleProvider provideHandle, MessageFilter messageFilter,
            HandleProvider cleanResource)
        {
            _ResourceCleaner = cleanResource;
            _Completion = new ManualResetEvent(false);
            _Disposed = false;
            Thread thread = new Thread(delegate()
            {
                _ApplicationContext = new ApplicationContext();
                _ApplicationContext.ThreadExit += new EventHandler(_ApplicationContext_ThreadExit);
                _Completion.Set();
                Form form = new Form();
                provideHandle(form.Handle);
                _WindowHandle = form.Handle;
                _MessageFilter = new CustomMessageFilter(messageFilter);
                Application.AddMessageFilter(_MessageFilter);
                Application.Run(_ApplicationContext);
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;
            thread.Start();
        }
        public void ExitLoop()
        {
            if (_Disposed)
                return;
            _Completion.WaitOne();
            _ApplicationContext.ExitThread();
        }
        void _ApplicationContext_ThreadExit(object sender, EventArgs e)
        {
            Application.RemoveMessageFilter(_MessageFilter);
            _ResourceCleaner(_WindowHandle);
            _Disposed = true;
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
