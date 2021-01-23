    string _x = string.Empty;
    public string X
    {
       set
       {
          if(value != this._x)
          {
             DoFancyListBoxWork();
             this._x = value;
          }
       }
       get
       {
          return this._x;
       }
    }
