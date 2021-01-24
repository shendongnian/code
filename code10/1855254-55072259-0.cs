    public class Card
    {
        public Card(int color, int val)
        {
            Color = color;
            Value = val;
        }
        public int Color { get; }
        public int Value { get; }
        // That might look nicer in the debugger (with less code).
        public override string ToString()
        {
            return "♥♣♦♠"[Color] + "A23456789TNQK"[Value];
        }
    }
