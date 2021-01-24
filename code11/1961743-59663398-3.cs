    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Block
    {
    	public Block(String ID, DateTime Start, DateTime End) { this.ID = ID; this.Start = Start; this.End = End; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    	public String ID { get; set; }
    }
    
    public class Presence
    {
    	public Presence(DateTime Arrival, DateTime Departure) { this.Arrival = Arrival; this.Departure = Departure; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
    
        public TimeSpan FlightTime;
    }
    
    public class Worker
    {
    	public Worker(string ssn) { this.ssn = ssn; }
    	public String ssn { get; set; }
        public List<Block> blocksWorked = new List<Block>();
    }
    
    public static class PresenceExtensions
    {
    	public static IEnumerable<Presence> CalculateFlightTimes(this IEnumerable<Presence> presences, Block block, Worker worker)
    	{
    		int iterationIndex = 0;
    		foreach (Presence presence in presences)
    		{
    			if (iterationIndex == 0)
    			{
    				presence.FlightTime = presence.Arrival > block.Start ? presence.Arrival - block.Start : TimeSpan.Zero;
    			}
    			else
    			{
    				presence.FlightTime = presence.Arrival - presences.ElementAt(iterationIndex - 1).Departure;
    				
    				if (iterationIndex == presences.Count() - 1){
    					presence.FlightTime += presence.Departure < block.End ? block.End - presence.Departure : TimeSpan.Zero;
    				}
    			}		
    			
    			iterationIndex++;
    		}
    
    		if (iterationIndex == 0)
    		{
    			Presence presence = new Presence(new DateTime(), new DateTime());
    			presence.FlightTime = block.End - block.Start;
    			presences = presences.Concat(new[] { presence });
    		}
    		else
    		{
    			worker.blocksWorked.Add(block);
    		}
    		
    		return presences;
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
    
    public static class ListExtensions
    {
    	public static String ToStr(this List<Block> blockList)
    	{
    		String str = "";
    		int blockIndex = 0;
    		
    		foreach (Block block in blockList)
    		{
    			str += block.ID + ", ";
    			
    			if (blockIndex == blockList.Count - 1)
    			{
    				str = str.Substring(0, str.Length - 2);
    			}
    			
    			blockIndex++;
    		}
    			
    		return str;
    	}
    }
    					
    public class AbsentDetectionProgram
    {
    	public static void Main()
    	{
    		Console.WriteLine("Process started..\n");
    		
    		// Assuming that these values are for one worker
    		
    		Worker worker = new Worker("1234567890");
    		
    		List<Block> blocks = new List<Block>();
    		blocks.Add(new Block("1", new DateTime(1899, 12, 30, 8, 30, 0), new DateTime(1899, 12, 30, 11, 45, 0)));
    		blocks.Add(new Block("2", new DateTime(1899, 12, 30, 13, 15, 0), new DateTime(1899, 12, 30, 17, 0, 0)));
    		blocks.Add(new Block("3", new DateTime(1899, 12, 30, 18, 15, 0), new DateTime(1899, 12, 30, 22, 0, 0)));
    		
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
    			IEnumerable<Presence> pairValue = pair.Value.CalculateFlightTimes(pair.Key, worker);
    			long minuteDiff = pairValue.GetTotalFlightTime().TicksToMinutes();		
    			
    			// If worker worked in that block (Assumed that if any presence of worker exists at the block time, then the worker worked in that block, otherwise not)
          		if (worker.blocksWorked.Contains(pair.Key))
    			{
    				if (minuteDiff > 15)
    				{
    					Console.WriteLine("Worker #" + worker.ssn + " - Total Worker Flight Time: " + minuteDiff);
          				Console.WriteLine("Worker #" + worker.ssn + " - Worker Work Time Details: [Block Start: " + pair.Key.Start + " Block End: " + pair.Key.End + " In-Out Count: " + pair.Value.Count() + "] The worker is out of the block for more than 15 min");	
    				}
    			}
    		}
    		
    		Console.WriteLine("\nSummary");
    		Console.WriteLine("-------");
    		if (worker.blocksWorked.Count == 0)
    		{
    			Console.WriteLine("Worker #" + worker.ssn + " didn't work in any block");
    		}
    		else
    		{
    			Console.WriteLine("Worker #" + worker.ssn + " worked in block(s) " + worker.blocksWorked.ToStr());
    			Console.WriteLine("Worker #" + worker.ssn + " didn't work in block(s) " + blocks.Except(worker.blocksWorked).ToList().ToStr());	
    		}
    		
    		Console.WriteLine("\nProcess finished..");
    	}
    }
