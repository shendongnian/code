    //You can also make PerValue class
    public struct PerValueInt
    {
        public int Value;
        public PerValueInt(int value)
        {
            Value = value;
        }
        public void Percent (float percent)
        {
            Value = (int)(Value * (percent / 100f));
        }
    }
