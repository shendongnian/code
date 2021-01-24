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
		RaceSession { get; set (INPC); }
		
		public int Hours => RaceSession.Duration.Hours;
		
		public RaceSessionViewModel(raceSession)
		{
			RaceSession = raceSession;
		}
		
		public void SetDurationHours(int hours)
		{
			RaceSession.Duration =
				Duration
                .Subtract(Duration.Hours)
                .Add(hours);
				
			NotifyPropertyChanged("Hours");
		}
	}
