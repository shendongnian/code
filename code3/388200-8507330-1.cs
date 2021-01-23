    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
				// example dates
    			var lookFor = new DateTime(2012, 12, 14, 16, 20, 02);
    			var readUntilDate = new DateTime(2012, 12, 14, 16, 20, 05);
    
    			using (var stream = File.OpenText("MyLogFile.txt"))
    			{
    				if (SeekToEntry(stream, lookFor) == false)
    				{
    					Console.WriteLine("Could not find entry for date {0}", lookFor);
    					return;
    				}
    
    				foreach (var line in ReadEntriesUntil(stream, readUntilDate))
    				{
    					Console.WriteLine("Line: {0}", line);
    				}
    			}
    		}
    
			// This method simply spits out one line at a time until it hits
			// the target cut-off.
    		static IEnumerable<string> ReadEntriesUntil(StreamReader stream, DateTime target)
    		{
    			while (true)
    			{
    				string line = stream.ReadLine();
    
    				if (line == null)
    				{
    					break;
    				}
    
    				if (line.StartsWith("!<<"))
    				{
    					DateTime entryDate;
    
    					if (DateTime.TryParseExact(line.Substring(3, 19).Replace(".", ""), @"ddMMyyyy HH:mm:ss",
    						CultureInfo.InvariantCulture, DateTimeStyles.None, out entryDate))
    					{
    						if (entryDate >= target)
    						{
    							break;
    						}
    					}
    				}
    
    				yield return line;
    			}
    		}
    
			// This method will bounce around the stream till it finds your
			// target entry date.
    		static bool SeekToEntry(StreamReader stream, DateTime target)
    		{
    			long from = 0;
    			long to = stream.BaseStream.Length;
    
    			while (true)
    			{
    				long testIndex = (to - from) / 2;
    
    				stream.BaseStream.Seek(testIndex, SeekOrigin.Begin);
    
    				var entryDate = GetNextEntryDate(stream, out testIndex);
    
    				if (entryDate == null || (from == to))
    				{
    					return false;
    				}
    
    				switch (entryDate.Value.CompareTo(target))
    				{
    					case -1:
    						// Found too low...
    						from = testIndex;
    						break;
    
    					case 1:
							// Fount too high...
    						to = testIndex;
    						break;
    
    					default: return true;
    				}
    			}
    		}
    
			// This is a function that is meant to keep seeking forward until
			// it hits an entry date.
    		static DateTime? GetNextEntryDate(StreamReader stream, out long actualIndex)
    		{
    			actualIndex = stream.BaseStream.Position;
    			DateTime? result = null;
    			string line = null;
    
    			// Find the next entry.
    			while ((line = stream.ReadLine()) != null && line.StartsWith("!<<") == false) ;
    
    			if (line != null)
    			{
    				actualIndex = stream.BaseStream.Position - line.Length;
    
    				DateTime timeStamp;
    
    				if (DateTime.TryParseExact(line.Substring(3, 19).Replace(".", ""), @"ddMMyyyy HH:mm:ss",
    					CultureInfo.InvariantCulture, DateTimeStyles.None, out timeStamp))
    				{
    					result = timeStamp;
    				}
    			}
    
    			return result;
    		}
    	}
    }
