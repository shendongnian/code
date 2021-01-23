    class Instrument {
         private string classCode;
         private string ticker;
         Instrument(string classCode, string ticker) {
              this.classCode = classCode;
              this.ticker = ticker;
         }
         public string ClassCode {
              get { return classCode; }
         }
         public string Ticker {
              get { return ticker; }
         }
    }
}
