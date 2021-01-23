        public class TimeLimitedSessionProxy : IMySession
        {
            private readonly IMySession _baseSession;
            private readonly TimeSpan _timeout;
            private DateTime _lastAccessedTime = DateTime.Now;
            public TimeLimitedSessionProxy(IMySession baseSession, TimeSpan timeout)
            {
                _baseSession = baseSession;
                _timeout = timeout;
            }
            #region IMySession members
            public void StoreName(string name)
            {
                IfNotTimedOut(() => _baseSession.StoreName(name));
            }
            public void StoreAddress(string address)
            {
                IfNotTimedOut(() => _baseSession.StoreAddress(address));
            }
            public void Commit()
            {
                IfNotTimedOut(() => _baseSession.Commit());
            }
            #endregion
            private void IfNotTimedOut(Action action)
            {
                if (DateTime.Now - _lastAccessedTime > _timeout)
                {
                    throw new TimeoutException("session timed out");
                }
                
                action();
                _lastAccessedTime = DateTime.Now;
            }
        }
