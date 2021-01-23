    public abstract class OutputFormatsBase<T> where T : OutputFormatsBase
    {
     private static readonly List<T> _listOfObjects = new List<T>();
    
     protected OutputFormatsBase()
     {
      _listOfObjects.Add((T)this);
     }
    }
