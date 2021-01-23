    class Lazy<T> {
      private bool IsEvaluated;
      private T Value;
      private Func<T> Suspension;
      public Lazy<T>(Func<T> susp) { Suspension = susp; }
      public static implicit operator T(Lazy<T> thunk) {
        if (thunk.IsEvaluated) {
          return thunk.Value;
        }
        thunk.Value = thunk.Suspension();
        thunk.IsEvaluated = true;
        return thunk.Value;
      }
    }
