    public static class TupleExtensions {
      public static Tuple<T1, T2, T3> 
        WhereItem3Is<T1, T2, T3>(this Tuple<T1, T2, T3> self, T3 newValue) {
        return Tuple.Create(self.Item1, self.Item2, newValue);
      }
      // other methods for Tuple<,,> or other Tuples...
    }
