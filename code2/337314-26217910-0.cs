    public class Comparer : System.Collections.IComparer
    {
      private readonly double _epsilon;
      public Comparer(double epsilon)
      {
        _epsilon = epsilon;
      }
      public int Compare(object x, object y)
      {
        var a = (double)x;
        var b = (double)y;
        double delta = System.Math.Abs(a - b);
        if (delta < _epsilon)
        {
          return 0;
        }
        return a.CompareTo(b);
      }
    }
    [NUnit.Framework.Test]
    public void MyTest()
    {
      var a = ...
      var b = ...
      NUnit.Framework.CollectionAssert.AreEqual(a, b, new Comparer(0.0001));
    }
