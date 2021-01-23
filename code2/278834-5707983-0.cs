    class Instrument
    {
         private string _classCode;
         private string _ticker;
    
         public string ClassCode
         {
            get
            {
              return _classCode;
             }
            set
            {
               if (_classCode == null)
                  _classCode = value;
            }
          }
         public string Ticker     {
            get
            {
              return _ticker;
             }
            set
            {
               if (_ticker == null)
                  _ticker = value;
            }
          }
    
    
    }
