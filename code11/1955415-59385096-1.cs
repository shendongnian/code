	public class Map
	{
		[JsonProperty("Alarm")]
		[JsonConverter(typeof(AlarmsConverter))]
		public Alarms Alarm { get; set; }
    
        // Remainder unchanged
