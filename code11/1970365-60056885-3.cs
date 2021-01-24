    foreach (var item in items)
    {
    	foreach (var list in dpIndexList)
    	{
    		DPIndex it = new DPIndex();
    		if (item.API == list.API)
    		{
    			it.File = list.File;
    			it.Location = list.Location;
    			dpNewIndexList.RemoveAll(x=> x.API == list.API);
    		}
    		else
    		{
    			it.API = list.API;
    			it.File = list.File;
    			it.Location = list.Location;
    		}
    		dpNewIndexList.Add(it);
    	}
    }
