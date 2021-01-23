    var objs = new Object[]
    {
    	new Object[]
    	{
    		new { Info = "item1", Count = 5749 },
    		new { Info = "item2", Count = 2610 },
    		new { Info = "item3", Count = 1001 },
    		new { Info = "item4", Count = 1115 },
    		new { Info = "item5", Count = 1142 },
    		"June",
    		37547
    	},
    	"Monday",
    	32347
    };
    
    String json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(objs);
