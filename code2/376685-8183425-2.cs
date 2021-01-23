    public class ServiceProxyHelper<TProxy, TChannel> : IDisposable
        where TProxy : ClientBase<TChannel>, new()
        where TChannel : class
    {
        ///
        /// Private instance of the WCF service proxy.
        ///
        private TProxy _proxy;
    
        ///
        /// Gets the WCF service proxy wrapped by this instance.
        ///
        public TProxy Proxy
        {
            get
            {
                if (_proxy != null)
                {
                    return _proxy;
                }
                else
                {
                    throw new ObjectDisposedException("ServiceProxyHelper");
                }
            }
        }
    
        public TChannel Channel { get; private set; }
    
        ///
        /// Constructs an instance.
        ///
        public ServiceProxyHelper()
        {
            _proxy = new TProxy();
        }
    
        ///
        /// Disposes of this instance.
        ///
        public void Dispose()
        {
            try
            {
                if (_proxy != null)
                {
                    if (_proxy.State != CommunicationState.Faulted)
                    {
                        _proxy.Close();
                    }
                    else
                    {
                        _proxy.Abort();
                    }
                }
            }
            catch (CommunicationException)
            {
                _proxy.Abort();
            }
            catch (TimeoutException)
            {
                _proxy.Abort();
            }
            catch (Exception)
            {
                _proxy.Abort();
                throw;
            }
            finally
            {
                _proxy = null;
            }
        }
    }
