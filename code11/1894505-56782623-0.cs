    colFirst.GroupFormatter = (BrightIdeasSoftware.OLVGroup group, BrightIdeasSoftware.GroupingParameters parms) =>
    {
        ObjectA a = (OjectA)group.Key;
        
	/* Add any processing code that you need */
	
	group.Task = " . . . ";
        group.Header = "Special Name: " + a.Name;
        group.Subtitle = $("Object A: {a.Index}, Total Water Consumption: {a.WaterConsumption}");
        
	// This is what is going to be used as a comparable in the GroupComparer below
	group.Id = a.ID;
	// This will create the iComparer that is needed to create the custom sorting of the groups
        parms.GroupComparer = Comparer<BrightIdeasSoftware.OLVGroup>.Create((x, y) => (x.GroupId.CompareTo(y.GroupId)));
    };
