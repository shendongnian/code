    public class LazyStream : IEnumerable<string>, IDisposable
    {
      LazyEnumerator le;
      public LazyStream(FileInfo file, Encoding encoding)
      {
        le = new LazyEnumerator(file, encoding);
      }
      #region IEnumerable<string> Members
      public IEnumerator<string> GetEnumerator()
      {
        return le;
      }
      #endregion
      #region IEnumerable Members
      System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
      {
        return le;
      }
      #endregion
      #region IDisposable Members
      private bool disposed = false;
      public void Dispose()
      {
        Dispose(true);
        GC.SuppressFinalize(this);
      }
      protected virtual void Dispose(bool disposing)
      {
        if (!this.disposed)
        {
          if (disposing)
          {
            if (le != null) le.Dispose();
          }
          disposed = true;
        }
      }
      #endregion
      class LazyEnumerator : IEnumerator<string>, IDisposable
      {
        StreamReader streamReader;
        const int chunksize = 1024;
        char[] buffer = new char[chunksize];
        string current;
        public LazyEnumerator(FileInfo file, Encoding encoding)
        {
          streamReader = new StreamReader(file.OpenRead(), encoding);
        }
        #region IEnumerator<string> Members
        public string Current
        {
          get { return current; }
        }
        #endregion
        #region IEnumerator Members
        object System.Collections.IEnumerator.Current
        {
          get { return current; }
        }
        public bool MoveNext()
        {
          if (streamReader.Peek() >= 0)
          {
            int readCount = streamReader.Read(buffer, 0, chunksize);
            current = new string(buffer, 0, readCount);
            return true;
          }
          else
          {
            return false;
          }
        }
        public void Reset()
        {
          throw new NotSupportedException();
        }
        #endregion
        #region IDisposable Members
        private bool disposed = false;
        public void Dispose()
        {
          Dispose(true);
          GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
          if (!this.disposed)
          {
            if (disposing)
            {
              if (streamReader != null) streamReader.Dispose();
            }
            disposed = true;
          }
        }
        #endregion
      }
    }
