    //create NumericTimeSeries; populate using foreach loop
    Infragistics.UltraChart.Resources.Appearance.NumericTimeSeries gwElevSeries = new Infragistics.UltraChart.Resources.Appearance.NumericTimeSeries();
          foreach (DataRow gwElevDr in qrySelectGwMonRecords)
          {
            gwElevSeries.Points.Add(new Infragistics.UltraChart.Resources.Appearance.NumericTimeDataPoint(System.DateTime.Parse(gwElevDr.ItemArray[2].ToString()),System.Double.Parse(gwElevDr.ItemArray[8].ToString()),"C",false));
          }
