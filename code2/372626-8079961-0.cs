    public class MyRange<T> where T: IComparable
    {
       public T From {get; private set;}
       public T Until {get; private set;}
       public MyRange(T from, T until)
       {
          From = from;
          Until = until;
       }
       public bool Contains(T value)
       {
          return value.CompareTo(From) >= 0 && value.CompareTo(Until) <= 0;
       }
    }
