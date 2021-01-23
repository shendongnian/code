    class LimitHolder
    {
        public Limit Limit { get; set; }
    }
    class Limit
    {
        public Limit(ParsedValue low, ParsedValue high)
        {
            Low = low;
            High = high;
        }
        public virtual ParsedValue Low { get; private set; }
        public virtual ParsedValue High { get; private set; }
    }
    class ParsedValue
    {
        public ParsedValue(double value, string unit)
        {
            Value = value;
            Unit = unit;
        }
        public virtual double Value { get; private set; }
        public virtual string Unit { get; private set; }
    }
