    public class Player
    {
    	public string Name;
    	public double Rank;
    }
    
    List<List<Player>> someOtherList = new List<List<Player>>
    								   {
    									   new List<Player> 
    										   {
    											   new Player {Name = "A", Rank = 1}, 
    											   new Player {Name = "B", Rank = 2}
    										   },
    									   new List<Player>
    										   {
    											   new Player {Name = "A", Rank = 2}, 
    											   new Player {Name = "C", Rank = 1}
    										   }
    								   };
    List<Player> plrs = 
    		(from p in someOtherList.SelectMany(singleList => singleList)
    		group p by p.Name into g
    		 select new Player { Name = g.Key, Rank = g.Average(x => x.Rank) })
    		 .OrderBy(x => x.Rank)
    		 .ToList();
    
    foreach (Player p in plrs)
    {
    	OverallPlayers.Add(p.Rank + ". " + p.Name);
    }
