    Dictionary<DateTime, Master> masterVolumes = new Dictionary<DateTime, Master>();
    List<Tank> tanks = SQLQueryToGetVolumes();
    DateTime dt;
    Master m;
    foreach(Tank tank in tanks)
    {
    	foreach(Volume volume in tank.volume)
    	{
    		//Since dates may have times associated, we strip the time.
    		dt = new DateTime(volume.date.Year, volume.date.Month, volume.date.Day);
    
    		//See if the day already exists
    		if (masterVolumes.ContainsKey(dt))
    		{
    			//If so, compare the current best volume
    			m = masterVolumes[dt];
    			if (m.bestVolume < volume.volume)
    			{
    				//There is a new master!
    				m.bestTankName = tank.name;
    				m.id = tank.id;
    				m.bestVolume = volume.volume;
    			}
    		}
    		else
    		{
    			//This date doesn't exist yet, so add it
    			m = new Master()
    			{
    				date = dt,
    				bestTankName = tank.name,
    				id = tank.id,
    				bestVolume = volume.volume
    			};
    			masterVolumes.Add(dt, m);
    		}
    	}
    }
    
    //At the end of this, the masterVolumes.Values will hold a collection of 
    // the highest volume Master for each day. 
    
    
