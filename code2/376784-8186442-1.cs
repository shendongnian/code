    class XmlHandlingClass : FileHandlingClass, IDisposable
    {
      PooledNameTable _table;
      /* yadda */
      public new void Dispose() // another possibility is explicit IDisposable.Dispose()
      {
        _table.Dispose();
        base.Dispose();
      }
    }
