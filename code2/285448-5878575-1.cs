	public class Instrument
	{
		private object thisLock = new object();
	
		public double Measure() 
		{ 
			lock(this.thisLock)
			{
				return 0; 
			}
		}
	}
	
	public class Device
	{
		public Instrument MeasuringInstrument { get; set; }
		private object measuringInstrumentLock = new object();
	
		public void DoMeasuring()
		{
			lock(this.measuringInstrumentLock)
			{
				var result = this.MeasuringInstrument.Measure();
			}
		}
    }
	
