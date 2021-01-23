    foreach (Listing listing in test)
    {
    	listing.Update();
    	if (listing is Listing_UK)
    		((Listing_UK)listing).PunchTheQueen();
    }
