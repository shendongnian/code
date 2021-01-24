    protected override void Dispose(bool disposing)
    {
        try
        {
            if (!_disposed)
            {
                if (disposing && (this._baseStream != null))
                    this._baseStream.Close();
                _disposed = true;
            }
         }
         finally
         {
            base.Dispose(disposing);
         }
    }
