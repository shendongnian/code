    void Read()            // Read in a nonblocking fashion.
    {
      while (true)
      {
        IAsyncResult r = _stream.BeginRead
         (_data, _bytesRead, _data.Length - _bytesRead, ReadCallback, null);
    
        // This will nearly always return in the next line:
        if (!r.CompletedSynchronously) return;   // Handled by callback
        if (!EndRead (r)) break;
      }
      Write();
    }
    
    void ReadCallback (IAsyncResult r)
    {
      try
      {
        if (r.CompletedSynchronously) return;
        if (EndRead (r))
        {
          Read();       // More data to read!
          return;
        }
        Write();
      }
      catch (Exception ex) { ProcessException (ex); }
    }
    
    bool EndRead (IAsyncResult r)   // Returns false if there’s no more data
    {
      int chunkSize = _stream.EndRead (r);
      _bytesRead += chunkSize;
      return chunkSize > 0 && _bytesRead < _data.Length;   // More to read
    }
