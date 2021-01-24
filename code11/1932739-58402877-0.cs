    List<dynamic> data = new List<dynamic>();
    foreach(var i in objects)
    {
    	List<dynamic> innerData = new List<dynamic>();
    	foreach(var j in i)
    	{
    		innerData.Add(j + " NEW");
    	}
    	data.Add(innerData);
    }
