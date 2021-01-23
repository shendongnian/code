    void Main()
    {
    	var list = new []{
    		new { LineId = 1 },
    		new { LineId = 1 },
    		new { LineId = 1 },
    		new { LineId = 2 },
    		new { LineId = 2 },
    		new { LineId = 1 },
    		new { LineId = 1 },
    		new { LineId = 3 },
    		new { LineId = 3 },
    		new { LineId = 1 }
    	};
    	
    	var groups = 	
            from i in list
            group i by i.LineId into g
            select new { LineId = g.Key, MyObject = g };
    }
