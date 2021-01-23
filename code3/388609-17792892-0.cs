    var nums = new []{1, 2, 3};
    var strings = new []{"a", "b", "c"};
    ForEach(nums, strings).Do((n, s) =>
    {
      Console.WriteLine(n + " " + s);
    });
    
    //-----------------------------
    
    public static TwoForEach<A, B> ForEach<A, B>(IEnumerable<A> a, IEnumerable<B> b)
    {
      return new TwoForEach<A, B>(a, b);   
    }
    
    public class TwoForEach<A, B>
    {
      private IEnumerator<A> a;
      private IEnumerator<B> b;
    
      public TwoForEach(IEnumerable<A> a, IEnumerable<B> b)
      {
        this.a = a.GetEnumerator();
        this.b = b.GetEnumerator();
      }
    
      public void Do(Action<A, B> action)
      {
        while (a.MoveNext() && b.MoveNext())
        {
          action.Invoke(a.Current, b.Current);
        }
      }
    }
