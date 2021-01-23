    private bool isX = false;
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
