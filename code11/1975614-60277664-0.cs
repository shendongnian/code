    public SeatType Type
    {
        get 
        { 
            if (_seatLetter == 'A' or _seatLetter == 'F')
            {
                return SeatType.Window;
            }
            else if (_seatLetter == 'C' or _seatLetter == 'D')
            {
                return SeatType.Aisle;
            }
            else
            {
                return SeatType.Middle;
            }
        }
    }
