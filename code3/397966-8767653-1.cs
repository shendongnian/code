	var telerik = Html.Telerik().Grid<ZeDate>("dates")
        .Name("MyGrid")
		.Columns(columns =>
        {
            columns.Bound(o => o.name);
			
			// Only render the date column if the designated
			if (Model.CanSeeDate)
			{
				columns.Bound(o => o.date1);
			}
        });
	
	// Only let the grid be filterable if allowed
	if (Model.GridFilterable)
	{
		telerik = telerik.Filterable();
	}
	
	// Perform other telerik setup
	telerik.Render();
