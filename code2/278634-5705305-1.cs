    private int? _result;
    public int Result {
      get {
         if (!_result.HasValue) {
           _result = A*B;
         }
         return _result.Value;
      }
    }
