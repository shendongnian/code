    public class IndicatorDTO
    {
         public int ObjID { get; set; }
        
         public int IndicatorValue { get; set; }
    }
    select new IndicatorDTO
    {
        ObjID = fx.ObjID,
        IndicatorValue = int.Parse(fx.IndicatorValue.Replace("S", "").Replace(" ", "").Replace("s", ""));
    }
