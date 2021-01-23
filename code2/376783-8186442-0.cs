    class FileHandlingClass : IDisposable
    {
      private FileStream _stm;
      /* Stuff to make class interesting */
      public void Disposable()
      {
        _stm.Dispose();
      }
      /*Note that we don't need a finaliser btw*/
    }
    
    class TextHandlingClass : FileHandlingClass
    {
      /* Stuff to make class interesting */
    }
