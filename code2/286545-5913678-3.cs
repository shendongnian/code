    using System;
    using CSG.Games.Data.SqlRepository.Model;
    
    namespace CSG.Games.Data.SqlRepository
    {
        /// <summary>
        /// Defines a transaction scope
        /// </summary>
        public class TransactionScope :IDisposable
        {
            private int _contextUsageCounter; // the number of usages in the context
            private readonly object _contextLocker; // to make access to _context thread safe
            private bool _disposed; // Indicates if the object is disposed
            internal TransactionScope()
            {
                Context = null;
                _contextLocker = new object();
                _contextUsageCounter = 0;
                _disposed = false;
            }
            internal MainDataContext Context { get; private set; }
            internal void Join()
            {
                // block the access to the context
                lock (_contextLocker)
                {
                    CheckDisposed();
                    // Increment the context usage counter
                    _contextUsageCounter++;
                    // If there is no context, create new
                    if (Context == null)
                        Context = new MainDataContext();
                }
            }
            internal void Leave()
            {
                // block the access to the context
                lock (_contextLocker)
                {
                    CheckDisposed();
                    // If no one using the context, leave...
                    if(_contextUsageCounter == 0)
                         return;
                    // Decrement the context usage counter
                    _contextUsageCounter--;
                    // If the context is in use, leave...
                    if (_contextUsageCounter > 0)
                        return;
                    // If the context can be disposed, dispose it
                    if (Context.Transaction != null)
                        Context.Dispose();
                    // Reset the context of this scope becuase the transaction scope ended
                    Context = null;
                }
            }
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            protected virtual void Dispose(bool disposing)
            {
                lock (_contextLocker)
                {
                    if (_disposed) return;
                    if (disposing)
                    {
                        if (Context != null && Context.Transaction != null)
                            Context.Dispose();
                        _disposed = true;
                    }
                }
            }        
            private void CheckDisposed()
            {
                if (_disposed)
                    throw new ObjectDisposedException("The TransactionScope is disposed");
            }
        }
     }
