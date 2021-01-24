    internal class ReferenceComparer<T> : IEqualityComparer<T> where T : class
    {
      static ReferenceComparer ()
      {
        Instance = new ReferenceComparer<T> ();
      }
      public static ReferenceComparer<T> Instance { get; }
      public bool Equals (T x, T y)
      {
        return ReferenceEquals (x, y);
      }
      public int GetHashCode (T obj)
      {
        return System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode (obj);
      }
    }
