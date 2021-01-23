    class UsuallyReadOnly { 
      //.. implementation
      public IDisposable AllowModification
      {
        get 
        {
            _allowModification = true;
            return new DisposableAction(()=>{ _allowModification = false; } );
         }
      }
    }
