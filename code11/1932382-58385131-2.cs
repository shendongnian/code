        class Image { ...
          public T SafeOperation<T>(Func<Image, T> operation)
          {
              Lock();
              try 
              {
                  return operation(this);
              }
              finally
              {
                   Unlock();
              }
          }
        …}
     
        img.SafeOperation(x => x.Write());
     
