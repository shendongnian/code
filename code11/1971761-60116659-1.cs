    private int _points;
    public int Points 
    { 
        get => _points; 
        set
        {
			_points = (value > 0)
							? value
							: 0; 
        }
    } 
