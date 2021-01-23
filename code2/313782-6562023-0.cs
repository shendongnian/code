    public enum YesNo {
      No = 0,
      Yes = 1,
      Null = -1
    }
    class TcmdChild : TcmdParent {
      public string fSgMrMs { get; set; }
      public YesNo fSgIsMale { get; set; }
      public int fSgValue1 { get; set; }
    }
