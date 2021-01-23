    public abstract BaseFoo
    {    
      /// <summary>
      /// Lol
      /// </summary>
      /// <exception cref="FubarException">Thrown when <paramref name="lol"> 
      /// is <c>null</c></exception>
      public void Bar(object lol)
      {
        if(lol == null)
          throw new FubarException();
        InnerBar(lol);
      }
        
      /// <summary>
      /// Handles execution of <see cref="Bar" />.
      /// </summary>
      /// <remarks><paramref name="lol"> is guaranteed non-<c>null</c>.</remarks>
      protected abstract void InnerBar(object lol);
    }
