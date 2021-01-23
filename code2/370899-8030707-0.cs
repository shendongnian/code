    #if NET_4_0
    
    namespace System{
      public interface IObservable<out T>
      {
        IDisposable Subscribe (IObserver<T> observer);
      }
    }
    
    #endif
