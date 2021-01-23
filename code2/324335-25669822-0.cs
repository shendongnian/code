    double offset = 0.5;//Choose an offset that is 1/2 of the range between x values
    for (int i = 0; i < chart1.Series[0].Points.Count; i++)
    {
        var customLabel = new CustomLabel();
        //NOTE: the custom label will appear at the mid-point between the FromPosition and the ToPosition
        customLabel.FromPosition = chart1.Series[0].Points[i].XValue - offset; //set beginning position (uses axis values)
        customLabel.ToPosition = chart1.Series[0].Points[i].XValue + offset; //set ending position  (uses axis values)
        customLabel.Text = chart1.Series[0].Points[i].XValue.ToString(); //set the text to display, you may want to format this value
        if (i == 3)
        {
        customLabel.ForeColor = Color.Green;//only change the 3rd label to be green, the rest will default to black
        }
        chart1.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);
    }
