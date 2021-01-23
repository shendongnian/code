    private void AddPointToChart(DateTime timestamp, double value, int series)
    {
        DataPoint dataPoint = new DataPoint(timestamp.ToOADate(), value);
        dataPoint.AxisLabel = "dd.MM.yy hh:mm";  // not sure how this will work, but try it.
        chart1.Series[series].Points.Add(dataPoint );
    }
