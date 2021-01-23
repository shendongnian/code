    public void ParseTVDB(Series ser)
    {
    	var oldEps = ser.TVDBEpisodes.ToList();
    	
    	foreach ( /*LOOP THROUGH FOUND EPISODES FROM TVDB */ )
    	{
    		string season = ;// parse season from website
    		string epnumber = ;// parse epnumber from website
    				
    		TVDBEpisode ep;
    		// Find an episode that matches this one already in database
    		var oldEp = oldEps.FirstOrDefault((o) => o.Season == season && o.EpNumber == epnumber);
    		if (oldEp == null)
    		{
    			// Create new item
    			ep = new TVDBEpisode();
    			// link with series (auto adds new item to the database)
    			ser.TVDBEpisodes.Add(ep);
    		}
    		else
    		{
    			// Get the item already in the database so we can modify it
    			ep = oldEp;
    		}
    		ep.SeasonNumber = season;
    		ep.EpisodeNumber = epnumber;
    
    		//PARSE THE REST OF THE INFO FOR THE EPISODE
    
    		// Set IsFound to true, because this item has been updated
    		ep.IsFound = true;
    
    		// Delete any item that was not updated (IsFound == false)
    		// Note that this only works on a fresh series that has been wiped where all eps start as false
    		context.TVDBEpisodes.DeleteAllOnSubmit(oldEps.Where((t) => !t.IsFound));
    		context.SubmitChanges();
    	}
    }
