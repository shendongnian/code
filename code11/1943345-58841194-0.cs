    public class Indicator
    {
        public int ObjID { get; set; }
    
        public string IndicatorValue { get; set; }
    
        public int IndicatorValueAsDouble => int.Parse(IndicatorValue.Replace("S", "").Replace(" ", "").Replace("s", ""));
    }
