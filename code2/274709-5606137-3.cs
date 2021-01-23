    // create a base date at the beginning of the method that fills the chart.
    // Today is just an example, you can use whatever you want 
    // as the date part is hidden using the format = "HH:mm:ss"
    DateTime baseDate = DateTime.Today; 
    
    var x = baseDate.AddSeconds((double)value1);
    var y = (double)value2;
    series.Points.addXY(x, y);
