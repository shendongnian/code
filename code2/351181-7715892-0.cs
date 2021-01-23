    public enum FrequencyUnit
    {
        SecondsSinceLastSend,
        UpdatesSinceLastSend,
    }
    public class Frequency
    {
        public double Value { get; set; }
        public FrequencyUnit Unit { get; set; }
    }
    public class Operator
    {
       Every, // Unary: e.g. every update; every 10 sec; every 5 updates
       Or,   // Nary: e.g. every 50 or every 20 sec (whichever's first)
       And,   // Nary: e.g. 19 messages and 20 sec have passed
       // etc.
    }
    public class UpdateSpec
    {
        public Frequency[] Frequencies { get; set; }
        public Operator Operator  { get; set; }
    }
