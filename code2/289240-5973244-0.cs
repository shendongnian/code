    public class MyRowComparer : IEqualityComparer<MyRow>
    {
       public override bool Equals(MyRow r1, MyRow r2)
       {
          // adjust the logic as per your need e.g. case-insensitive etc
          return r1.Col1 == r2.Col1 && r1.Col2 == r2.Col2;
       }
    
       public override int GetHashCode(MyRow r)
       {
          // TODO: add null check etc
          return r.Col1.GetHashCode() ^ r.Col2.GetHashCode()
       }
    }
    
    IEnumerable<MyRow> myList = ...;
    ...
    myList.Distinct(new MyRowComparer());
