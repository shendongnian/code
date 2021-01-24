	public class RaceSession : INPC
	{
		INPCProperties
		
		RaceSession(inpcProperties)
		{
			INPCProperties = inpcProperties;
		}
	}
	
	public class RaceSessionViewModel : INPC
	{
		public RaceSession RaceSession { get; set (INPC); }
		
		public int Hours => RaceSession.Duration.Hours;
		
		public RaceSessionViewModel(raceSession)
		{
			RaceSession = raceSession;
		}
		
		private void SetDurationHours(int hours)
		{
			RaceSession.Duration =
				Duration
                .Subtract(Duration.Hours)
                .Add(hours);
				
			NotifyPropertyChanged("Hours");
		}
	}
