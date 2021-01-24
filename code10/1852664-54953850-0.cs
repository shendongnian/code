    public class BidCostFormatted
    {
        private readonly BidCostModel _model;
        public string Code => _model.Code;
        public string Month1 => _model.Month1.ForView();
        public string Month2 => _model.Month2.ForView();
        public string Month3 => _model.Month3.ForView();  
        public BidCostFormatted(BidCostModel model) => _model = model;       
    }
    public static class Extensions
    {
        public static string ForView(this decimal? value)
        {
            if (value.HasValue)
            {
                return value.Value.ToString("N");
            }
            return string.Empty;
        }
    }
