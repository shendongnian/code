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
