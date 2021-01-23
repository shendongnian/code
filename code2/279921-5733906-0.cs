    public class TimeIterator
	{
		public DateTime CurrDateTime { get; set; }
				
		public IEnumerable<DateTime> GetTimes(short count)
		{
			for (short i = 1; i <= count; i++)
				yield return this.CurrDateTime.AddHours(i * 12);			
		}
		public TimeIterator()
		{
			this.CurrDateTime = DateTime.Now;
		}
	}
