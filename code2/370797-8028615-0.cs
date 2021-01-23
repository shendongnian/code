    public class Seat {
      private string _SeatKey;
      private Rectangle _SeatRectangle;
      public Seat(string seatKey, Rectangle seatRectangle) {
        _SeatKey = seatKey;
        _SeatRectangle = seatRectangle;
      }
      public string SeatKey {
        get { return _SeatKey; }
      }
      public Rectangle SeatRectangle {
        get { return _SeatRectangle; }
        set { _SeatRectangle = value; }
      }
    }
