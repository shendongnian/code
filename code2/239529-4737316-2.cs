        /// <summary>
        /// Abstract base class for Disposable types.    
        /// </summary>
        /// <remarks>This class makes it easy to correctly implement the Disposable pattern, so if you have a class which should
        /// be IDisposable, you can inherit from this class and implement the DisposeManagedResources and the
        /// DisposeUnmanagedResources (if necessary).
        /// </remarks>
        public abstract class Disposable : IDisposable
        {
            private bool                    _disposed = false;
    
            /// <summary>
            /// Releases the managed and unmanaged resources.
            /// </summary>
            public void Dispose()
            {
                Dispose (true);
                GC.SuppressFinalize (this);
            }
    
            /// <summary>
            /// Releases the unmanaged and managed resources.
            /// </summary>
            /// <param name="disposing">When disposing is true, the managed and unmanaged resources are
            /// released.
            /// When disposing is false, only the unmanaged resources are released.</param>
            [System.Diagnostics.CodeAnalysis.SuppressMessage ("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly")]
            protected void Dispose( bool disposing )
            {
                // We can suppress the CA1063 Message on this method, since we do not want that this method is 
                // virtual.  
                // Users of this class should override DisposeManagedResources and DisposeUnmanagedResources.
                // By doing so, the Disposable pattern is also implemented correctly.
    
                if( _disposed == false )
                {
                    if( disposing )
                    {
                        DisposeManagedResources ();
                    }
                    DisposeUnmanagedResources ();
    
                    _disposed = true;
                }
            }
    
            /// <summary>
            /// Override this method and implement functionality to dispose the 
            /// managed resources.
            /// </summary>
            protected abstract void DisposeManagedResources();
    
            /// <summary>
            /// Override this method if you have to dispose Unmanaged resources.
            /// </summary>
            protected virtual void DisposeUnmanagedResources()
            {
            }
    
            /// <summary>
            /// Releases unmanaged resources and performs other cleanup operations before the
            /// <see cref="Disposable"/> is reclaimed by garbage collection.
            /// </summary>
            [System.Diagnostics.CodeAnalysis.SuppressMessage ("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly")]
            ~Disposable()
            {
    #if DEBUG
                // In debug-builds, make sure that a warning is displayed when the Disposable object hasn't been
                // disposed by the programmer.
    
                if( _disposed == false )
                {
                    System.Diagnostics.Debug.Fail ("There is a disposable object which hasn't been disposed before the finalizer call: {0}".FormatString (this.GetType ().Name));
                }
    #endif
                Dispose (false);
            }
        }
