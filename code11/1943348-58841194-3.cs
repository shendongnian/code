    public class IndicatorDTO
    {
         public int ObjID { get; set; }
        
         public double IndicatorValue { get; set; }
    }
    select new IndicatorDTO
    {
        ObjID = fx.ObjID,
        IndicatorValue = double.Parse(fx.IndicatorValue.Replace("S", "").Replace(" ", "").Replace("s", ""));
    }
