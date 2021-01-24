    private void TimeCheck()
    {
        string WrongTime = "....";
        if (_TimeOne == WrongTime  && _TimeTwo == WrongTime )
        {
            _TimeOne = _TimeTwo = DateTime.Now.ToString();
        }
        else if (_TimeOne == WrongTime) 
        {
            _TimeOne = _TimeTwo;
        }
        else if (_TimeTwo == WrongTime)
        {
            _TimeTwo = _TimeOne;
        }
    }
