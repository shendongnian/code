    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Block
    {
    	public Block(DateTime Start, DateTime End) { this.Start = Start; this.End = End; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
    
    public class Presence
    {
    	public Presence(DateTime Arrival, DateTime Departure) { this.Arrival = Arrival; this.Departure = Departure; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
    
        public TimeSpan FlightTime;
    }
    
    public static class PresenceExtensions
    {
    	public static void CalculateFlightTimes(this IEnumerable<Presence> presences, Block block)
    	{
    		int iterationIndex = 0;
    		foreach (Presence presence in presences)
    		{
    			if (iterationIndex > 0)
    			{
    				presence.FlightTime = presence.Arrival - presences.ElementAt(iterationIndex - 1).Departure;	
    			}
    			
    			iterationIndex++;
    		}
    		
    		// If there is only one presence record and the departure is before block end and there is 15 minutes difference
    		if (iterationIndex == 1)
    		{
    			Presence presence = presences.ElementAt(0);		
    			if (presence.Departure < block.End.AddMinutes(-15)) {
    				presence.FlightTime = block.End - presence.Departure;
    			}
    		}
    	}
        public static TimeSpan GetTotalFlightTime(this IEnumerable<Presence> presences)
        {
            return new TimeSpan(presences.Sum(r => r.FlightTime.Ticks));
        }
    	public static long TicksToMinutes(this TimeSpan ts)
    	{
    		return (ts.Ticks / (60 * 10000000));
    	}
    }
    
    public static class BlockExtensions
    {
        public static Dictionary<Block, IEnumerable<Presence>> FilterPresences(this IEnumerable<Block> blocks, IEnumerable<Presence> presences)
        {
            Dictionary<Block, IEnumerable<Presence>> result = new Dictionary<Block, IEnumerable<Presence>>();
            foreach (Block block in blocks)
            {
    			result.Add(block, presences.Where(p => p.Arrival <= block.End && p.Departure >= block.Start));
            }
    
            return result;
        }
    }
    					
    public class AbsentDetectionProgram
    {
    	public static void Main()
    	{
    		Console.WriteLine("Process started..");
    		
    		// Assuming that these values are for one worker
    		
    		List<Block> blocks = new List<Block>();
    		blocks.Add(new Block(new DateTime(1899, 12, 30, 8, 30, 0), new DateTime(1899, 12, 30, 11, 45, 0)));
    		blocks.Add(new Block(new DateTime(1899, 12, 30, 13, 15, 0), new DateTime(1899, 12, 30, 17, 0, 0)));
    		List<Presence> presences = new List<Presence>();
    		presences.Add(new Presence(new DateTime(1899, 12, 30, 8, 3, 0), new DateTime(1899, 12, 30, 9, 21, 0)));
    		presences.Add(new Presence(new DateTime(1899, 12, 30, 9, 36, 0), new DateTime(1899, 12, 30, 10, 34, 0)));
    		presences.Add(new Presence(new DateTime(1899, 12, 30, 10, 45, 0), new DateTime(1899, 12, 30, 12, 5, 0)));
    		presences.Add(new Presence(new DateTime(1899, 12, 30, 13, 3, 0), new DateTime(1899, 12, 30, 14, 24, 0)));
    		presences.Add(new Presence(new DateTime(1899, 12, 30, 14, 34, 0), new DateTime(1899, 12, 30, 16, 14, 0)));
    		presences.Add(new Presence(new DateTime(1899, 12, 30, 16, 27, 0), new DateTime(1899, 12, 30, 18, 2, 0)));
    
    		Dictionary<Block, IEnumerable<Presence>> filteredList = blocks.FilterPresences(presences);
    		foreach (KeyValuePair<Block, IEnumerable<Presence>> pair in filteredList)
    		{
    			pair.Value.CalculateFlightTimes(pair.Key);
    			
    			Console.WriteLine("Total Worker Flight Time: " + pair.Value.GetTotalFlightTime().TicksToMinutes());
    			
          		if (pair.Value.GetTotalFlightTime().TicksToMinutes() > 15)
    			{
          			Console.WriteLine("Worker Work Time Details: [Block Start: " + pair.Key.Start + " Block End: " + pair.Key.End + " In-Out Count: " + pair.Value.Count() + "] The worker is out of the block for more than 15 min");
    			}
    		}
    		
    		Console.WriteLine("Process finished..");
    	}
    }
