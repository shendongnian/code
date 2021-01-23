    // Mockup of a GUI element and mouse position.
    var timeBar = new { X = 100, Width = 200 };
    int mouseX = 180;
     
    // Find out which date on the time bar the mouse is positioned on,
    // assuming it represents whole of 2014.
    var timeRepresentation = new Interval<int>( timeBar.X, timeBar.X + timeBar.Width );
    DateTime start = new DateTime( 2014, 1, 1 );
    DateTime end = new DateTime( 2014, 12, 31 );
    var thisYear = new Interval<DateTime, TimeSpan>( start, end );
    DateTime hoverOver = timeRepresentation.Map( mouseX, thisYear );
     
    // If the user clicks, zoom in to this position.
    double zoomLevel = 0.5;
    double zoomInAt = thisYear.GetPercentageFor( hoverOver );
    Interval<DateTime, TimeSpan> zoomed = thisYear.Scale( zoomLevel, zoomInAt );
     
    // Iterate over the interval, e.g. draw labels.
    zoomed.EveryStepOf( TimeSpan.FromDays( 1 ), d => DrawLabel( d ) );
