    static class CrmToRealTypeConverter : IConverter
    {
        #region IConverter Members
        public static DateTime? Convert(CrmDateTime obj)
        {
            return obj.IsNull == false ? (DateTime?)obj.UserTime : null;
        }
    
        public static int? Convert(CrmNumber obj)
        {
            return obj.IsNull == false ? (int?)obj.Value : null;
        }
    
        public static decimal? Convert(CrmDecimal obj)
        {
            return obj.IsNull == false ? (decimal?)obj.Value : null;
        }
    
        public static double? Convert(CrmDouble obj)
        {
            return obj.IsNull == false ? (double?)obj.Value : null;
        }
    
        public static float? Convert(CrmFloat obj)
        {
            return obj.IsNull == false ? (float?)obj.Value : null;
        }
    
        public static decimal? Convert(CrmMoney obj)
        {
            return obj.IsNull == false ? (decimal?)obj.Value : null;
        }
    
        public static bool? Convert(CrmBoolean obj)
        {
            return obj.IsNull == false ? (bool?)obj.Value : null;
        }
    }
