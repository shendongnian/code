    private TimeSpan _delayBy; 
    public TimeSpan DelayBy { 
       get { 
          return this._delayBy
       }
       set {
          this._delayBy = XmlConvert.ToTimeSpan(someVal)
       }
    }
