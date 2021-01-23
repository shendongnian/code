    for (int i = 0; i < timeRanges.Count; i++)
    {
        string theLabel = timeRanges[i].ItemLabel;
        int pointIndex = connectedTimeRangeSeries.Points.AddXY(timeRanges[i].ItemId + 1,   timeRanges[i].StartConnectionTime, timeRanges[i].StopConnectionTime);
        connectedTimeRangeSeries.Points[pointIndex].AxisLabel = theLabel;
    }
