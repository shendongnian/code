     private bool? allowNulls = null;
     public bool AllowNulls  {
        get { return allowNulls.GetValueOrDefault(false); }
        set { allowNulls = value; }
     }
     public bool AllowNullsWasSet() { return allowNulls.HasValue; }
