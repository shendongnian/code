    public class Class1Comparer : IComparer<Class1>, IComparer
    {
      public int Compare(Class1 x, Class1 y)
      {
        if(x == null)
          return y == null ? 0 : -1;
        if(y == null)
          return 1;
        return DateTime.Compare(x.myDate, y.myDate);
      }
      public int Compare(object x, object y)
      {
        //This has no type-checking because you said above it isn't needed. I would normally add some just in case.
        return Compare((Class1)x, (Class1)y);
      }
    }
