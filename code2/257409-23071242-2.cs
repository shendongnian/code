    int period = 50;
    
    // Simply filtering a list of doubles
    IEnumerable<double> inputDoubles;
    IEnumerable<double> outputDoubles = inputDoubles.MovingAverage(period);   
    
    // Or, use a selector to filter T into a list of doubles
    IEnumerable<Point> inputPoints; // assuming you have initialised this
    IEnumerable<double> smoothedYValues = inputPoints.MovingAverage(pt => pt.Y, period);
