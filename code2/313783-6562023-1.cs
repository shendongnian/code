    public enum YesNo {
      No = 0,
      Yes = 1,
      Null = -1
    }
    class CommandChild : CommandParent {
      private string _fSgMrMs;
      private string _fSgValue1;
      public string fSgMrMs {
        get { return _fSgMrMs; }
        set {
          if (value.Length > 2) {
            throw new ArgumentException("The length of fSgMrMs can not be more than 2.");
          }
          _fSgMrMs = value;
        }
      }
      public YesNo fSgIsMale { get; set; }
      public int fSgValue1 {
        get { return _fSgValue1; }
        set {
          if (value < 0 || value > 3) {
            throw new ArgumentException("The value of fSgValue1 hase to be between 0 and 3.");
          }
          _fSgValue1 = value;
        }
      }
    }
