    // The following line goes in your form constructor
    this.chart1.AxisViewChanged += new EventHandler<ViewEventArgs> (this.chart1_AxisViewChanged);
    
    private void chart1_AxisViewChanged(object sender, ViewEventArgs e)
    { 
        if (e.Axis.AxisName == AxisName.X) 
        { 
            int start = (int)e.Axis.ScaleView.ViewMinimum; 
            int end = (int)e.Axis.ScaleView.ViewMaximum; 
            // Use two separate arrays, one for highs (same as temp was in Shavram's original)
            // and a new one for lows which is used to set the Y axis min.
            double[] tempHighs = chart1.Series[0].Points.Where((x, i) => i >= start && i <= end).Select(x => x.YValues[0]).ToArray();
            double[] tempLows = chart1.Series[0].Points.Where((x, i) => i >= start && i <= end).Select(x => x.YValues[1]).ToArray();
            double ymin = tempLows.Min();
            double ymax = tempHighs.Max();
 
            chart1.ChartAreas[0].AxisY.ScaleView.Position = ymin; 
            chart1.ChartAreas[0].AxisY.ScaleView.Size = ymax - ymin; 
        } 
    } 
