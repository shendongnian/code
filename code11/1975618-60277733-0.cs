    class Program
    {
        static void Main(string[] args)
        {
            Seat seat = new Seat('A');
        }
    }
    public class Seat
    {
        public SeatType Type { get; set; }
        public Seat(char seatLetter)
        {
            SetSeatType(seatLetter);
        }
        public void SetSeatType(char seatLetter)
        {
            switch (seatLetter)
            {
                case 'A':
                case 'F':
                    Type = SeatType.Window;
                    break;
                case 'C':
                case 'D':
                    Type = SeatType.Aisle;
                    break;
                default:
                    Type = SeatType.Middle;
                    break;
            }
        }
    }
    public enum SeatType
    {
        Window,
        Aisle,
        Middle
    }
