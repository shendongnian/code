    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Collections.Generic;
    
    
    public class Program
    {
    	public static void Main()
    	{
    
    		    List<Item> items = new List<Item>()
                {
                    new Item() { ID = 1, MonitoringString = "1006410001D0", JunctionListId = 267, area_id = 910064 , CompanyProfileId = 7},
                    new Item() { ID = 2, MonitoringString = "1206420001D0", JunctionListId = 268, area_id = 910065 , CompanyProfileId = 7},
                    new Item() { ID = 3, MonitoringString = "1306440001D0", JunctionListId = 267, area_id = 910064 , CompanyProfileId = 7},
                    new Item() { ID = 4, MonitoringString = "1506450001D0", JunctionListId = 268, area_id = 910065 , CompanyProfileId = 7},
                    new Item() { ID = 5, MonitoringString = "1606470001D0", JunctionListId = 267, area_id = 910064 , CompanyProfileId = 7},
                    new Item() { ID = 6, MonitoringString = "1806480001D0", JunctionListId = 268, area_id = 910065 , CompanyProfileId = 7},
                    new Item() { ID = 7, MonitoringString = "1006420001D0", JunctionListId = 267, area_id = 910064 , CompanyProfileId = 7},
                    new Item() { ID = 8, MonitoringString = "1006470001D0", JunctionListId = 268, area_id = 910065 , CompanyProfileId = 7},
                    new Item() { ID = 9, MonitoringString = "1006490001D0", JunctionListId = 267, area_id = 910064 , CompanyProfileId = 7},
                    new Item() { ID = 10, MonitoringString = "1006430001D0", JunctionListId = 268, area_id = 910065 , CompanyProfileId = 7},
                    new Item() { ID = 11, MonitoringString = "1006460001D0", JunctionListId = 285, area_id = 910066 , CompanyProfileId = 8},
                    new Item() { ID = 12, MonitoringString = "1006438001D0", JunctionListId = 268, area_id = 910067 , CompanyProfileId = 8},
    
                };
    
    
    
                var result = items.GroupBy(item => item.JunctionListId).Select(g => g.FirstOrDefault(gx => gx.ID == g.Max(x => x.ID))).ToList();
    
                foreach (var item in result)
                {
                    Console.WriteLine(string.Format("{0},{1},{2},{3}",item.ID, item.MonitoringString, item.JunctionListId,item.area_id, item.CompanyProfileId));
                }
    
                Console.ReadLine();
    	}
    	
    	    class Item
        {
            public int ID { get; set; }
            public string MonitoringString { get; set; }
            public int JunctionListId { get; set; }
            public int area_id { get; set; }
            public int CompanyProfileId { get; set; }
        }
    }
