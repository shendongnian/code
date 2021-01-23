    foreach (Series charttypes in mschart1.Series) 
    { 
         if(charttypes.ChartArea == "area2")
         {
           charttypes.ChartType = SeriesChartType.Pie; 
           ...
         }
         else if(charttypes.ChartArea == "area1")
         {
           charttypes.ChartType = SeriesChartType.StackedColumn; 
           ...
         }
    }
