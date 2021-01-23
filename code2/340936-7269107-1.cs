    public class ValueChainComparer : IComparer<ValueChain>
    {
      private IComparer<string> StringComparer;
      public ValueChainComparer()
        : this(global::System.StringComparer.OrdinalIgnoreCase)
      {
      }
      public ValueChainComparer(IComparer<string> stringComparer)
      {
        StringComparer = stringComparer;
      }
      #region IComparer<ValueChain> Members
      public int Compare(ValueChain x, ValueChain y)
      {
        //todo: null checks
        int comparison = 0;
        foreach (var pair in x.Values.Zip
          (y.Values, (xVal, yVal) => new { XVal = xVal, YVal = yVal }))
        {
          //types match?
          if (pair.XVal.GetType().Equals(pair.YVal.GetType()))
          {
            if (pair.XVal is string)
              comparison = StringComparer.Compare(
                (string)pair.XVal, (string)pair.YVal);
            else if (pair.XVal is int) //unboxing here - could be changed
              comparison = Comparer<int>.Default.Compare(
                (int)pair.XVal, (int)pair.YVal);
            if (comparison != 0)
              return comparison;
          }
          else  //according to your rules strings are always greater than numbers.
          {
            if (pair.XVal is string)
              return 1;
            else
              return -1;
          }
        }
        if (comparison == 0) //ah yes, but were they the same length?
        {
          //whichever one has the most values is greater
          return x.ValueCount == y.ValueCount ? 
            0 : x.ValueCount < y.ValueCount ? -1 : 1;
        }
        return comparison;
      }
      #endregion
    }
