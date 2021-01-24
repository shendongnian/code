    private int _points;
    public int Points 
    { 
        get => _points; 
        set
        {
            if (value >= 0)
              _points = value;
            else 
               _points = 0; 
        }
    } 
