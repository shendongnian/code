    // Methods that work like LISP's (mapcar) when used with
    // more than 1 list argument (2 to 4 included here, add
    // versions for more arguments as needed).
    //
    // The methods will only yield as many results as there
    // are elements in the argument sequence that yields the
    // fewest elements, in cases where argument sequences do
    // not all yield the same number of elements (which is
    // the same behavior as their LISP counterpart).
    //
    // An interesting twist, is that we make these methods
    // extension methods of the invoked function, because it
    // doesn't seem natural to make one of the sequences of
    // arguments the target.
    //
    // Nonetheless, they can still be called as non-extension
    // methods through the declaring type:
    //
    // (Untested):
    //
    //   string[] fruit = new string[]
    //      {"apples", "oranges", "pears", "banannas"};
    //
    //   double[] prices = new double[] {1.25, 1.50, 1.00, 0.75};
    //
    //   int[] amounts = new int[] {12, 8, 24, 5};
    //
    //
    //   Func<int, string, double, string> func =
    //     ( amount, name, price ) => string.Format(
    //        "{{0} lbs. of {1} @ ${2:F2} / lb. = ${3:F2}",
    //         amount, name, price, amount * price );
    //
    //   var invoice = func.Map( amounts, fruit, prices );
    //
    //   foreach( string item in invoice )
    //      Console.WriteLine( item );
    //
    // It's also worth noting that CLR 3.5 introduces the
    // "Zip" extension method, that allows mapping of two
    // sequences to a function taking two arguments, but
    // without some wild contortion involving currying and
    // multiple calls to Zip, it can't solve the general
    // problem (mapping n sequences to a function taking
    // that many arguments).
    public static class Sequence
    {
      // Map elements of 2 sequences to the arguments of
      // a function taking 2 args, and return results:
      public static IEnumerable<T> Map<A1, A2, T>(
        this Func<A1, A2, T> func,
        IEnumerable<A1> a1,
        IEnumerable<A2> a2
      {
        using( IEnumerator<A1> e1 = a1.GetEnumerator() )
        using( IEnumerator<A2> e2 = a2.GetEnumerator() )
        {
          IEnumerator[] args = new IEnumerator[] {e1, e2};
          while( args.TrueForAll( e => e.MoveNext() ) )
          {
            yield return func( e1.Current, e2.Current );
          }
        }
      }
      // 3 arguments
      public static IEnumerable<T> Map<A1, A2, A3, T>( this
        this Func<A1, A2, A3, T> func,
        IEnumerable<A1> a1,
        IEnumerable<A2> a2,
        IEnumerable<A3> a3
      {
        using( IEnumerator<A1> e1 = a1.GetEnumerator() )
        using( IEnumerator<A2> e2 = a2.GetEnumerator() )
        using( IEnumerator<A3> e3 = a3.GetEnumerator() )
        {
          IEnumerator[] args = new IEnumerator[] {e1, e2, e3};
          while( args.TrueForAll( e => e.MoveNext() ) )
          {
            yield return func( e1.Current, e2.Current, e3.Current );
          }
        }
      }
      // 4 arguments
      public static IEnumerable<T> Map<A1, A2, A3, A4, T>(
        this Func<A1, A2, A3, A4, T> func,
        IEnumerable<A1> a1,
        IEnumerable<A2> a2,
        IEnumerable<A3> a3,
        IEnumerable<A4> a4
      {
        using( IEnumerator<A1> e1 = a1.GetEnumerator() )
        using( IEnumerator<A2> e2 = a2.GetEnumerator() )
        using( IEnumerator<A3> e3 = a3.GetEnumerator() )
        using( IEnumerator<A4> e4 = a4.GetEnumerator() )
        {
          IEnumerator[] args = new IEnumerator[] {e1, e2, e3, e4};
          while( args.TrueForAll( e => e.MoveNext() ) )
          {
            yield return func( e1.Current, e2.Current, e3.Current, e4.Current );
          }
        }
      }
    }
