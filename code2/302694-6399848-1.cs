    public abstract class Media : ISynchronizeInvoke
    {
            //....
            private readonly System.Threading.SynchronizationContext _currentContext = System.Threading.SynchronizationContext.Current;
    
            private readonly System.Threading.Thread _mainThread = System.Threading.Thread.CurrentThread;
            
            private readonly object _invokeLocker = new object();
            //....
            #region ISynchronizeInvoke Members
               
            public bool InvokeRequired
            {
                get
                {
                    return System.Threading.Thread.CurrentThread.ManagedThreadId != this._mainThread.ManagedThreadId;
                }
            }
    
            /// <summary>
            /// This method is not supported!
            /// </summary>
            /// <param name="method"></param>
            /// <param name="args"></param>
            /// <returns></returns>
            [Obsolete("This method is not supported!", true)]
            public IAsyncResult BeginInvoke(Delegate method, object[] args)
            {
                throw new NotSupportedException("The method or operation is not implemented.");
            }
    
            /// <summary>
            /// This method is not supported!
            /// </summary>
            /// <param name="method"></param>
            /// <param name="args"></param>
            /// <returns></returns>
            [Obsolete("This method is not supported!", true)]
            public object EndInvoke(IAsyncResult result)
            {
                throw new NotSupportedException("The method or operation is not implemented.");
            }
    
            public object Invoke(Delegate method, object[] args)
            {
                if (method == null)
                {
                    throw new ArgumentNullException("method");
                }
                lock (_invokeLocker)
                {
                    object objectToGet = null;
    
                    SendOrPostCallback invoker = new SendOrPostCallback(
                    delegate(object data)
                    {
                        objectToGet = method.DynamicInvoke(args);
                    });
    
                    _currentContext.Send(new SendOrPostCallback(invoker), method.Target);
    
                    return objectToGet;
                }
            }
    
            public object Invoke(Delegate method)
            {
                return Invoke(method, null);
            }
    
            #endregion//ISynchronizeInvoke Members
    
    }
