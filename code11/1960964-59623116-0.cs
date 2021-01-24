    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var listOfChanels = new List<Channels>{ new Channels("1", "1", "1")};
    		
    		UpdateOrAdd(listOfChanels, new Channels("1", "2", "1"));
    		UpdateOrAdd(listOfChanels, new Channels("2", "2", "2"));
    		UpdateOrAdd(listOfChanels, new Channels("2", "3", "3"));
    		
    		foreach(var item in listOfChanels)
            	Console.WriteLine(item.CalleeExt + item.CallerExt + item.ChannelName);
    	}
    	
    	private static void UpdateOrAdd(List<Channels> list, Channels newObject)
    	{
    		var item = list.FirstOrDefault(p => p.CalleeExt == newObject.CalleeExt && p.CallerExt == newObject.CallerExt);
    		
    		if(item == null){
    			list.Add(newObject);
    		}else{
    			item.ChannelName = newObject.ChannelName;
    		}
    	}
    	
    	public class Channels
    	{
    		internal string CallerExt { get; set; }
    		internal string ChannelName { get; set; }
    		internal string CalleeExt { get; set; }
    
    		public Channels(string CallerExt, string ChannelName, string CalleeExt)
    		{
    			this.CallerExt = CallerExt;
    			this.ChannelName = ChannelName;
    			this.CalleeExt = CalleeExt;
    		}
    	}
    }
