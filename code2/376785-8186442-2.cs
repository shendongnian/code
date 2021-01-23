    //Allow for Disposal override
    class FileHandlingClass : IDisposable
    {
      private FileStream _stm;
      /* Stuff to make class interesting */
      public virtual void Disposable()
      {
        _stm.Dispose();
      }
      /*Note that we don't need a finaliser btw*/
    }
    
    //Still don't care here
    class TextHandlingClass : FileHandlingClass
    {
      /* Stuff to make class interesting */
    }
    
    class XmlHandlingClass : FileHandlingClass
    {
      PooledNameTable _table;
      /* yadda */
      public override void Dispose()
      {
        _table.Dispose();
        base.Dispose();
      }
    }
