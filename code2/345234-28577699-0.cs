    [System.Security.SecuritySafeCritical]  // auto-generated
    protected override void Dispose(bool disposing)
    {
        // Nothing will be done differently based on whether we are 
        // disposing vs. finalizing.  This is taking advantage of the
        // weak ordering between normal finalizable objects & critical
        // finalizable objects, which I included in the SafeHandle 
        // design for FileStream, which would often "just work" when 
        // finalized.
        try {
            if (_handle != null && !_handle.IsClosed) {
                // Flush data to disk iff we were writing.  After 
                // thinking about this, we also don't need to flush
                // our read position, regardless of whether the handle
                // was exposed to the user.  They probably would NOT 
                // want us to do this.
                if (_writePos > 0) {
                    FlushWrite(!disposing); // <- Note this
                }
            }
        }
    ...
