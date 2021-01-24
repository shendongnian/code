    public SeatType Type
    {
        get 
        { 
            switch (_seatLetter)
			{
				case 'A':
				case 'F':
					return SeatType.Window;
				case 'C':
				case 'D':
					return SeatType.Aisle;
				default:
					return SeatType.Middle;
            }
        }
    }
