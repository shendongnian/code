    public class Indicator
    {
        public int ObjID { get; set; }
    
        public string IndicatorValue { get; set; }
    
        public double IndicatorValueAsDouble => double.Parse(IndicatorValue.Replace("S", "").Replace(" ", "").Replace("s", ""));
    }
