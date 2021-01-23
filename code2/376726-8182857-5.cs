    // a.k.a base.Dispose(disposing)
    protected override void Dispose(bool disposing)
    {
        lock (this._stream)
        {
            try
            {
                if (disposing)
                {
                    this._stream.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }
    }
 
 
