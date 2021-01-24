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
    		
    		if (presences.Count() == 0)
    		{
    			Presence presence = new Presence(block.Start, block.End);
    			presence.FlightTime = block.End - block.Start;
    			presences = presences.Concat(new[] { presence });
    		}
    		else
    		{
    			IEnumerable<Presence> absentAfterOneBlockEndPresences = presences.Where(p => p.Arrival > block.End);
    			IEnumerable<Presence> absentBeforeOneBlockStartPresences = presences.Where(p => p.Departure < block.Start);
    			presences = presences.Except(absentAfterOneBlockEndPresences).Except(absentBeforeOneBlockStartPresences);
    
    			foreach (Presence presence in presences)
    			{
    				if (iterationIndex == 0)
    				{
    					presence.FlightTime = presence.Arrival > block.Start ? presence.Arrival - block.Start : TimeSpan.Zero;
    
    					if (iterationIndex == presences.Count() - 1){
    						presence.FlightTime += presence.Departure < block.End ? block.End - presence.Departure : TimeSpan.Zero;
    					}
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
    			
    			worker.blocksWorked.Add(block);
    
    			// Calculating arrival after block ends
    			if (absentAfterOneBlockEndPresences.Count() > 0)
    			{
    				if (presences.Count() == 0 || presences.Where(p => p.Departure < block.Start).Count() == presences.Count())
    				{
    					Presence firstPresence = absentAfterOneBlockEndPresences.ElementAt(0);
    					firstPresence.FlightTime = firstPresence.Arrival - block.End;	
    					presences = presences.Concat(new[] { firstPresence });
    					
    					if (worker.blocksWorked.Contains(block))
    					{
    						worker.blocksWorked.Remove(block);
    					}
    				}			
    			}
    			
    			// Calculating departure before block starts (This may not be needed. If it is not needed, this code part can be safely disabled)
    			if (absentBeforeOneBlockStartPresences.Count() > 0)
    			{		
    				if (presences.Count() == 0 || presences.Where(p => p.Arrival > block.End).Count() == presences.Count())
    				{
    					Presence lastPresence = absentBeforeOneBlockStartPresences.ElementAt(absentBeforeOneBlockStartPresences.Count() - 1);
    					lastPresence.FlightTime = block.Start - lastPresence.Departure;	
    					presences = presences.Concat(new[] { lastPresence });
    					
    					if (worker.blocksWorked.Contains(block))
    					{
    						worker.blocksWorked.Remove(block);
    					}
    				}			
    			}			
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
    	public static bool SameDayControl(this DateTime dateTime1, DateTime dateTime2)
    	{
    		return dateTime1.Date.Equals(dateTime2.Date);
    	}
    }
    
    public static class BlockExtensions
    {
        public static Dictionary<Block, IEnumerable<Presence>> FilterPresences(this IEnumerable<Block> blocks, IEnumerable<Presence> presences)
        {
            Dictionary<Block, IEnumerable<Presence>> result = new Dictionary<Block, IEnumerable<Presence>>();
            foreach (Block block in blocks)
            {
    			// Filtering same date block and presences regarding absent times before block starts and after block ends
    			result.Add(block, presences.Where(p => block.End.SameDayControl(p.Arrival.Date) && block.Start.SameDayControl(p.Departure.Date) && ((p.Arrival <= block.End && p.Departure >= block.Start) || (p.Arrival > block.End) || (p.Departure < block.Start))));
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
    		
    		List<Block> blocks = new List<Block>();
    		blocks.Add(new Block("1", new DateTime(1899, 12, 30, 8, 30, 0), new DateTime(1899, 12, 30, 11, 45, 0)));
    		blocks.Add(new Block("2", new DateTime(1899, 12, 30, 13, 15, 0), new DateTime(1899, 12, 30, 17, 0, 0)));
    		blocks.Add(new Block("3", new DateTime(1899, 12, 30, 18, 15, 0), new DateTime(1899, 12, 30, 22, 0, 0)));
    		
    		blocks.Add(new Block("4", new DateTime(1899, 12, 1, 8, 30, 0), new DateTime(1899, 12, 1, 11, 45, 0)));
    		blocks.Add(new Block("5", new DateTime(1899, 12, 1, 13, 15, 0), new DateTime(1899, 12, 1, 17, 0, 0)));
    		blocks.Add(new Block("6", new DateTime(1899, 12, 2, 8, 30, 0), new DateTime(1899, 12, 2, 11, 45, 0)));
    		blocks.Add(new Block("7", new DateTime(1899, 12, 2, 13, 15, 0), new DateTime(1899, 12, 2, 17, 0, 0)));
    		blocks.Add(new Block("8", new DateTime(1899, 12, 3, 8, 30, 0), new DateTime(1899, 12, 3, 11, 45, 0)));
    		blocks.Add(new Block("9", new DateTime(1899, 12, 3, 13, 15, 0), new DateTime(1899, 12, 3, 17, 0, 0)));
    		blocks.Add(new Block("10", new DateTime(1899, 12, 4, 8, 30, 0), new DateTime(1899, 12, 4, 11, 45, 0)));
    		blocks.Add(new Block("11", new DateTime(1899, 12, 4, 13, 15, 0), new DateTime(1899, 12, 4, 17, 0, 0)));
    		blocks.Add(new Block("12", new DateTime(1899, 12, 5, 8, 30, 0), new DateTime(1899, 12, 5, 11, 45, 0)));
    		blocks.Add(new Block("13", new DateTime(1899, 12, 5, 13, 15, 0), new DateTime(1899, 12, 5, 17, 0, 0)));
    		blocks.Add(new Block("14", new DateTime(1899, 12, 6, 8, 30, 0), new DateTime(1899, 12, 6, 11, 45, 0)));
    		blocks.Add(new Block("15", new DateTime(1899, 12, 6, 13, 15, 0), new DateTime(1899, 12, 6, 17, 0, 0)));
    		
    		// Only two worker is calculated
    		
    		Worker worker1 = new Worker("1234567890");
    		Worker worker2 = new Worker("1234567891");
    		
    		List<Presence> presencesForWorker1 = new List<Presence>();
    		presencesForWorker1.Add(new Presence(new DateTime(1899, 12, 30, 8, 3, 0), new DateTime(1899, 12, 30, 9, 21, 0)));
    		presencesForWorker1.Add(new Presence(new DateTime(1899, 12, 30, 9, 36, 0), new DateTime(1899, 12, 30, 10, 34, 0)));
    		presencesForWorker1.Add(new Presence(new DateTime(1899, 12, 30, 10, 45, 0), new DateTime(1899, 12, 30, 12, 5, 0)));
    		presencesForWorker1.Add(new Presence(new DateTime(1899, 12, 30, 13, 3, 0), new DateTime(1899, 12, 30, 14, 24, 0)));
    		presencesForWorker1.Add(new Presence(new DateTime(1899, 12, 30, 14, 34, 0), new DateTime(1899, 12, 30, 16, 14, 0)));
    		presencesForWorker1.Add(new Presence(new DateTime(1899, 12, 30, 16, 27, 0), new DateTime(1899, 12, 30, 18, 2, 0)));
    		
    		List<Presence> presencesForWorker2 = new List<Presence>();
    		presencesForWorker2.Add(new Presence(new DateTime(1899, 12, 1, 7, 0, 0), new DateTime(1899, 12, 1, 12, 0, 0)));//
    		presencesForWorker2.Add(new Presence(new DateTime(1899, 12, 1, 13, 0, 0), new DateTime(1899, 12, 1, 16, 55, 0)));
    		presencesForWorker2.Add(new Presence(new DateTime(1899, 12, 2, 8, 40, 0), new DateTime(1899, 12, 2, 11, 39, 0)));
    		presencesForWorker2.Add(new Presence(new DateTime(1899, 12, 2, 13, 0, 0), new DateTime(1899, 12, 2, 16, 55, 0)));
    		presencesForWorker2.Add(new Presence(new DateTime(1899, 12, 3, 8, 30, 0), new DateTime(1899, 12, 3, 9, 0, 0)));
    		presencesForWorker2.Add(new Presence(new DateTime(1899, 12, 3, 9, 10, 0), new DateTime(1899, 12, 3, 10, 0, 0)));
    		presencesForWorker2.Add(new Presence(new DateTime(1899, 12, 3, 10, 15, 0), new DateTime(1899, 12, 3, 12, 1, 0)));
    		presencesForWorker2.Add(new Presence(new DateTime(1899, 12, 3, 13, 0, 0), new DateTime(1899, 12, 3, 16, 55, 0)));
    		presencesForWorker2.Add(new Presence(new DateTime(1899, 12, 4, 8, 0, 0), new DateTime(1899, 12, 4, 14, 0, 0)));
    		presencesForWorker2.Add(new Presence(new DateTime(1899, 12, 5, 12, 1, 0), new DateTime(1899, 12, 5, 17, 0, 0)));
    		presencesForWorker2.Add(new Presence(new DateTime(1899, 12, 6, 8, 0, 0), new DateTime(1899, 12, 6, 12, 59, 0)));
    		
    		Dictionary<Worker, List<Presence>> workerPresenceDict = new Dictionary<Worker, List<Presence>>();
    		workerPresenceDict.Add(worker1, presencesForWorker1);
    		workerPresenceDict.Add(worker2, presencesForWorker2);
    		
    		foreach (KeyValuePair<Worker, List<Presence>> workerPresencePair in workerPresenceDict)
    		{
    			Worker worker = workerPresencePair.Key;
    			List<Presence> presences = workerPresencePair.Value;
    			Dictionary<Block, IEnumerable<Presence>> filteredList = blocks.FilterPresences(presences);
    		
    			foreach (KeyValuePair<Block, IEnumerable<Presence>> pair in filteredList)
    			{
    				Block block = pair.Key;
    				IEnumerable<Presence> presencesIEN = pair.Value;
    				
                    // If there is more than one presences, then same day control is not needed because of earlier filtering operation
    				if (presencesIEN.Count() > 1 || (presencesIEN.Count() == 1 && block.End.SameDayControl(presencesIEN.ElementAt(0).Arrival) && block.Start.SameDayControl(presencesIEN.ElementAt(0).Departure)))
    				{
    					IEnumerable<Presence> pairValue = presencesIEN.CalculateFlightTimes(block, worker);
    					long minuteDiff = pairValue.GetTotalFlightTime().TicksToMinutes();		
    
    					// If there is more than 15 minutes difference
    					if (minuteDiff > 15)
    					{
    						Console.WriteLine("Worker #" + worker.ssn + " - Total Worker Flight Time: " + minuteDiff);
    						Console.WriteLine("Worker #" + worker.ssn + " - Worker Work Time Details: [Block Start: " + block.Start + " Block End: " + block.End + " In-Out Count: " + pairValue.Count() + "] The worker is out of the block for more than 15 min");	
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
    				Console.WriteLine("Worker #" + worker.ssn + " didn't work in block(s) " + blocks.Except(worker.blocksWorked).ToList().ToStr() + "\n");	
    			}
    		}
    		
    		Console.WriteLine("Process finished..");
    	}
    }
