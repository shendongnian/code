	public class DataEntry
	{
		public ICollection<WorkSchedule> Schedules { get; set; }
		
		public void DoWork()
		{
			Schedules.Add(new WorkSchedule
			{
				Start = DateTime.Now
			});
		}
	}
