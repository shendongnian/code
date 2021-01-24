    using System.Collections.Generic;
    using System.Linq;
    public static IEnumerable<Player> AssignPlayerRanks(IEnumerable<Player> players)
    	{
    		return players
    			.OrderByDescending(player => player.Points)
    			.Select((player, index) => 
    					{
    						player.Rank = (++index).ToString();
    						return player;
    					});
    	}
