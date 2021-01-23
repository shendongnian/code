    public class DisposableList : List<IDisposable>, IDisposable
    {
       //this is all you need if you will ONLY use it in a using statement or explicitly call Dispose;
       //there is a more developed pattern that performs disposal automatically on finalization.
       public void Dispose()
       {
          foreach(var disposable in this)
             disposable.Dispose();
       }
    }
    
    ...
    
    using(var disposables = new DisposableList{new ObjectOne(), new ObjectTwo()})
    {
       //unfortunately, you must now cast the items back to their types 
       //in order to use them as anything but IDisposables.
       var objectOne = (ObjectOne)disposables[0];
       var objectTwo = (ObjectTwo)disposables[1];
    
       ...
    }
