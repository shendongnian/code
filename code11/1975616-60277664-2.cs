    public SeatType Type
    {
        get 
        { 
            if (_seatLetter == 'A' || _seatLetter == 'F')
            {
                return SeatType.Window;
            }
            else if (_seatLetter == 'C' || _seatLetter == 'D')
            {
                return SeatType.Aisle;
            }
            else
            {
                return SeatType.Middle;
            }
        }
    }
