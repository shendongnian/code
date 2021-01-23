     Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(10, 60, 720, 432);
     Excel.Chart chart = myChart.Chart;
     Excel.ChartObject oldchartObject = (Excel.ChartObject)VstoWorksheet.ChartObjects(1);
     Excel.Chart oldchart = oldchartObject.Chart;
     Excel.SeriesCollection seriesCollection = (Excel.SeriesCollection)chart.SeriesCollection(Type.Missing);
     Excel.SeriesCollection oldSeriesCollection = (Excel.SeriesCollection)oldchart.SeriesCollection(Type.Missing);
     Excel.Series oSeries;
     for (int i = 1; i <= (ColumnCount - 2); i++)
     {
         oSeries = seriesCollection.NewSeries();
         Excel.Series oOldSeries = oldSeriesCollection.Item(i);
         oOldSeries = (Excel.Series)oldchart.SeriesCollection(i);
         oSeries.MarkerStyle = oOldSeries.MarkerStyle;
         oSeries.Name = oOldSeries.Name;
     }
