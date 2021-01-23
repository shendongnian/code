    foreach (Series charts in fbchart.Series)
    {
        foreach (DataPoint point in charts.Points)
        {
	       switch (point.AxisLabel)
	        {
		       case "Neutral": point.Color = Color.Red; break;
		       case "Happy": point.Color = Color.Green; break;
		       case "Sad": point.Color = Color.Orange; break;
	         }
             point.Label = string.Format("{0:0} - {1}", point.YValues[0], point.AxisLabel);
		}
     }	
