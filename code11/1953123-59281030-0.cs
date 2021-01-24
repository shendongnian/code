     private void btnChart_Click(object sender, EventArgs e)
     {
         //Make your Query , Get Count Value for RushOrder and NormalOrder
         //Check for Null Value
         //Pass the Count to the DrawPieChart() function
         //Sample Chart Generation 
         int nRushOrderCount = Convert.ToInt32(txtRushOrder.Text);
         int nNormalOrderCount = Convert.ToInt32(txtNormalOrder.Text);
         DrawPieChart(nRushOrderCount, nNormalOrderCount);
      }
      private void DrawPieChart(int nRushOrder, int nNormalOrder)
      {
         //reset your chart series and legends
         chart1.Series.Clear();
         chart1.Legends.Clear();
         //Add a new Legend(if needed) and do some formating
         chart1.Legends.Add("MyLegend");
         chart1.Legends[0].LegendStyle = LegendStyle.Table;
         chart1.Legends[0].Docking = Docking.Bottom;
         chart1.Legends[0].Alignment = StringAlignment.Center;
         chart1.Legends[0].Title = "Order Details";
         chart1.Legends[0].BorderColor = Color.Black;
         //Add a new chart-series
         string seriesname = "MySeriesName";
         chart1.Series.Add(seriesname);
         //set the chart-type to "Pie"
         chart1.Series[seriesname].ChartType = SeriesChartType.Pie;
         //Add some datapoints so the series. in this case you can pass the values to this method
         chart1.Series[seriesname].Points.AddXY("Rush Order", nRushOrder);
         chart1.Series[seriesname].Points.AddXY("Normal Order", nNormalOrder);
         chart1.Series[seriesname].IsValueShownAsLabel = true;
      }
