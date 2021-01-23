		public class TimePeriodType {
			public string Name { set; get; }
			public int Min { set; get; }
			public int Max { set; get; }
		}
		List<TimePeriodType> _periods = new List<TimePeriodType>() { 
			new TimePeriodType() { Name="Hours", Max=6, Min=1 }, 
			new TimePeriodType() { Name="Minutes", Max=59, Min=20 }
		};
		public List<TimePeriodType> Periods {
			get { return _periods; }
			set { _periods = value; }
		}
