    public class ProfitVals {
        private static double _hiprofit;
		public static Double HiProfit
		{
			get { return _hiprofit; }
			set { _hiprofit = value; }
		}
		public ProfitVals() {
            // assign default value
			HiProfit = 0.09;
		}
	}
