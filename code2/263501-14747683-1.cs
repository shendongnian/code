    // actual variable having true/false
    private bool isX = false;
    // variable holding wither above is set/not-set i.e. null/not-null
    private bool isXSet = false;
    public bool IsX
    {
       get
       {
          if (isXSet)
          {
             return isX;
          }
          else
          {
             isX = GetX(); // this could be time consuming.
             isXSet = true;
             return isX;
          }
       }
    }
