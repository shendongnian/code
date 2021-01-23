    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public class P
    {
    	struct DataItem
    	{
    		public System.DateTime time;
    		public int number;
    	}
    
    	public static void Main(string[] args)
    	{
    		var ItemList = new DataItem[] {} ;
    		var groups = ItemList
    			.GroupBy(item => new { item.time.Hour, item.time.Minute });
    		var sums   = groups
    			.ToDictionary(g => g.Key, g => g.Sum(item => item.number));
    
    
    		// lookups now become trivially easy:
    
    		int partialByTimeSlot = sums[new {Hour=23,Minute=10}];
    	}
    }
