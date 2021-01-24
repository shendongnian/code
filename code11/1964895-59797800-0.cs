    namespace SODemo
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			//Load the data
    			List<ActivityTime> activities = ReadInActivityTimes();
    			
    			//Trying to do a lambda on the activities list would be out of scope
    			// for a normal use of a Linq query. Because each item requires knowledge of the
    			// next item in the list. So there needs to be a step where the related pairs are grouped.
    			List<ActivityTimePair> pairs = CreatePairs(activities);
    			
    			//Now we can run a Linq query. 
    			List<TimeSpan> output = pairs
    				.Where(p => p.HasBoth)
    				.Select(p => p.GetTimeSpan().Value)
    				.ToList();
    				
    			output.ForEach(ts => 
    			{
    				Console.WriteLine(ts.ToString());
    			});
    		}
    		
    		static List<ActivityTime> ReadInActivityTimes()
    		{
    			return new List<ActivityTime>() {
    				new ActivityTime() { Activity = "IN", TimeStamp = DateTime.Parse("2019-11-12 06:45:14.1234042" },
    				new ActivityTime() { Activity = "OUT", TimeStamp = DateTime.Parse("2019-11-12 09:20:14.2291323" },
    				new ActivityTime() { Activity = "IN", TimeStamp = DateTime.Parse("2019-11-12 10:35:14.4541043" },
    				new ActivityTime() { Activity = "OUT", TimeStamp = DateTime.Parse("2019-11-12 19:36:14.3431042" },
    				new ActivityTime() { Activity = "IN", TimeStamp = DateTime.Parse("2019-11-13 09:33:14.6541045" },
    				new ActivityTime() { Activity = "OUT", TimeStamp = DateTime.Parse("2019-11-13 18:35:14.3441042" },
    				new ActivityTime() { Activity = "IN", TimeStamp = DateTime.Parse("2019-11-14 06:32:14.2361042" },
    				new ActivityTime() { Activity = "OUT", TimeStamp = DateTime.Parse("2019-11-14 12:23:14.2345044" },
    				new ActivityTime() { Activity = "IN", TimeStamp = DateTime.Parse("2019-11-14 16:24:14.3791034" },
    				new ActivityTime() { Activity = "IN", TimeStamp = DateTime.Parse("2019-11-15 11:10:14.2245446" },
    				new ActivityTime() { Activity = "OUT", TimeStamp = DateTime.Parse("2019-11-15 19:44:14.5349504" }
    			};
    		}
    		
    		static List<ActivityTimePair> CreatePairs(List<ActivityTime> activities)
    		{
    			List<ActivityTimePair> pairs = new List<ActivityTimePair>();
    			
    			for (int i = 0; i < activities.Count; i++)
    			{
    				if (pairs.Count == 0) //first one
    				{
    					pairs.Add(new ActivityTimePair());
    				}
    				
    				if (activities[i].Activity == "IN")
    				{
    					//If the last pair has an OUT, then we need a new pair
    					if (pairs.Last().OUT != null)
    					{
    						pairs.Add(new ActivityTimePair() { IN = activities[i].Activity });
    					}
    					//handle case where there are 2 IN's in a row
    					else if (pairs.Last().IN != null) 
    					{
    						//Means there is 2 INs in a row
    						pairs.Add(new ActivityTimePair() { IN = activities[i].Activity });
    					}
    					else 
    					{
    						pairs.Last().IN = activities[i].Activity;
    					}
    				}
    				
    				if (activities[i].Activity == "OUT")
    				{
    					//If the last pair has an OUT, there are 2 OUT's in a row
    					if (pairs.Last().OUT != null)
    					{
    						//Means there is 2 OUTs in a row
    						pairs.Add(new ActivityTimePair() { OUT = activities[i].Activity });
    					}
    					else if (pairs.Last().IN != null) 
    					{
    						pairs.Last().OUT = activities[i].Activity;
    					}
    					//handle case where there then we need a new pair
    					else 
    					{
    						pairs.Add(new ActivityTimePair() { OUT = activities[i].Activity });
    					}
    				}
    			}
    			
    			return pairs;
    		}
    	}
    
    	class ActivityTime
    	{
    		public string Activity { get; set; }
    		public DateTime TimeStamp { get; set; }
    	}
    	
    	class ActivityTimePair
    	{
    		public ActivityTime IN { get; set; }
    		public ActivityTime OUT { get; set; }
    		
    		public bool HasBoth 
    		{
    			get
    			{
    				return IN != null && OUT != null;
    			}
    		}
    		
    		public TimeSpan? GetTimeSpan()
    		{
    			if (HasBoth)
    			{
    				return OUT.TimeStamp.Subtract(IN.TimeStamp);
    			}
    			else 
    			{
    				return null;
    			}
    		}
    	}
    }
