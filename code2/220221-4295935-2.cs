    public int State
    {
      get { return _State; }
      set
      {
        _State = value;
        if (OnStateChanged != null)
        {
          OnStateChanged(this, null);
        }
      }
    }
