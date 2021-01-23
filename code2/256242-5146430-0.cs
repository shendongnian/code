    private void FillChart()
    {
        int blockSize = 100;
    
        // generates random data (i.e. 30 * blockSize random numbers)
        var valuesArray = Enumerable.Range(0, blockSize * 30).Select(x => rand.Next(1, 10)).ToArray();
    
        // clear the chart
        chart1.Series.Clear();
    
        // fill the chart
        var series = chart1.Series.Add("My Series");
        series.ChartType = SeriesChartType.Line;
        series.XValueType = ChartValueType.Int32;
        for (int i = 0; i < valuesArray.Length; i++)
            series.Points.AddXY(i, valuesArray[i]);
        var chartArea = chart1.ChartAreas[series.ChartArea];
    
        // set view range to [0,max]
        chartArea.AxisX.Minimum = 0;
        chartArea.AxisX.Maximum = valuesArray.Length;
    
        // enable autoscroll
        chartArea.CursorX.AutoScroll = true;
    
        // let's zoom to [0,blockSize] (e.g. [0,100])
        chartArea.AxisX.ScaleView.Zoomable = true;
        chartArea.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;
        int position = 0;
        int size = blockSize;
        chartArea.AxisX.ScaleView.Zoom(position, size);
    
        // disable zoom-reset button (only scrollbar's arrows are available)
        chartArea.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
    
        // set scrollbar small change to blockSize (e.g. 100)
        chartArea.AxisX.ScaleView.SmallScrollSize = blockSize;
    }
