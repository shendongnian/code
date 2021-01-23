    NumericTimeSeries waterDataSeries = null;
    foreach (DataRow currentRow in myDataTable.Rows)
    {
    waterDataSeries.Points.Add(new NumericTimeDataPoint(Convert.ToDateTime(currentRow["Date"]), Convert.ToDouble(currentRow["qtyMeasure"]), "Water", false));
    }
    Chart.Series.Add(waterDataSeries);
