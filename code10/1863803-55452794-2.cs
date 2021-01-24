    //You can also make PerValue class
    public struct PerValueInt
    {
        public T Value;
        public PerValue(int value)
        {
            Value = value;
        }
        public T Percent (float percent)
        {
            Value = Value * (percent / 100f);
        }
    }
