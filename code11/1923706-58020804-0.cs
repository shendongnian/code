    internal class MyObject
    {
        public double Value1 { get; set; }
        public double Value2 { get; set; }
        public double Value3 { get; set; }
        public double CalculatedValue =>
            value1* Math.Pow((1 + value2 / 100), value3);
    }
