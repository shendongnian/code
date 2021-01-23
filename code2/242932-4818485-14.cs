    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using System.Threading;
    
    namespace System
    {
        public class MessageLoop
        {
            #region Fields
    
            private Object _Lock;
            private ApplicationContext _ApplicationContext;
            private CustomMessageFilter _MessageFilter;
            private HandleProvider _ResourceCleaner;
            private ManualResetEvent _Completion;
            private bool _Disposed;
    
            #endregion // Fields
    
            #region Constructors
    
            /// <summary>
            /// Run a second message pump that will filter messages asyncronously
            /// </summary>
            /// <param name="provideHandle">A delegate that provide a window handle for
            ///     resource initializing</param>
            /// <param name="messageFilter">A delegate for message filtering</param>
            /// <param name="cleanResources">A delegate for proper resource cleaning
            ///     before quitting the loop</param>
            /// <param name="background">State if the loop should be run on a background
            ///     thread or not. If background = false, please be aware of the
            ///     possible race conditions on application shut-down.</param>
            public MessageLoop(HandleProvider initializeResources, MessageFilter messageFilter,
                HandleProvider cleanResources, bool background)
            {
                _Lock = new Object();
                _ResourceCleaner = cleanResources;
                _Completion = new ManualResetEvent(false);
                _Disposed = false;
    
                Thread thread = new Thread(delegate()
                {
                    _ApplicationContext = new ApplicationContext();
                    Form form = new Form();
                    initializeResources(form.Handle);
                    _MessageFilter = new CustomMessageFilter(messageFilter);
                    Application.AddMessageFilter(_MessageFilter);
    
                    // Signal resources initalizated
                    _Completion.Set();
    
                    // If background = true, do resource cleaning on ProcessExit event
                    if (background)
                    {
                        AppDomain.CurrentDomain.ProcessExit +=
                            new EventHandler(CurrentDomain_ProcessExit);
                    }
    
                    // Run the message loop
                    Application.Run(_ApplicationContext);
    
                    // Clean resource before leaving the thread
                    cleanResources(form.Handle);
    
                    // Signal resources cleaned
                    _Completion.Set();
                });
                thread.SetApartmentState(ApartmentState.STA);
                thread.IsBackground = background;
                thread.Start();
    
                // Before returning the instace, wait for thread resources initialization
                _Completion.WaitOne();
            }
    
            #endregion // Constructors
    
            #region Inquiry
    
            /// <summary>
            /// Early exit the message loop
            /// </summary>
            public void ExitLoop()
            {
                lock (_Lock)
                {
                    if (_Disposed)
                        return;
    
                    // Completion was already signaled in the constructor 
                    _Completion.Reset();
    
                    // Tell the message loop thread to quit
                    _ApplicationContext.ExitThread();
    
                    // Wait for thread resources cleaning
                    _Completion.WaitOne();
    
                    _Disposed = true;
                }
            }
    
            #endregion // Inquiry
    
            #region Event handlers
    
            void CurrentDomain_ProcessExit(object sender, EventArgs e)
            {
                lock (_Lock)
                {
                    if (_Disposed)
                        return;
    
                    // Completion was already signaled in the constructor 
                    _Completion.Reset();
    
                    // Tell the message loop thread to quit
                    _ApplicationContext.ExitThread();
    
                    // Wait for thread resources cleaning
                    _Completion.WaitOne();
    
                    _Disposed = true;
                }
            }
    
            #endregion // Event handlers
    
            #region Support
    
            public delegate void HandleProvider(IntPtr handle);
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
    
            #endregion // Support
        }
    }
