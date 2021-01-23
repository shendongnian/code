    class Instrument
    {
      private string _classCode;
      private string _ticker;
      public string ClassCode{ get { return _classCode; } }
      public string Ticker{ get { return _ticker; } }
      private ClassCode() {}
      public ClassCode(string classCode, string ticker)
      {
        _classCode = classCode;
        _ticker = ticker;
      }
    }
