        @model IEnumerable<CustomerSales>        
    @using Chart = System.Web.UI.DataVisualization.Charting.Chart   
    @{    
        ViewBag.Title = "Index";
    }
    
    <h2>Index</h2>
    
    <p>
        @Html.ActionLink("Create New", "Create")
    </p>
    <table>
        <tr>
            <th>
                Name
            </th>
            <th>
                Sales
            </th>
        </tr>
    
    @foreach (var item in Model)
    {
        <tr>
            <td>
                @item.Name
            </td>
            <td>
                @{
                    
        var chart = new Chart();
        chart.ChartAreas.Add(new ChartArea());
        chart.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
        chart.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
        chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
        chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
        chart.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
        chart.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
        chart.ChartAreas[0].AxisX.LineWidth = 0;
        chart.ChartAreas[0].AxisY.LineWidth = 0;
    
        chart.Series.Add(new Series());
            // Assign the random number to the chart to create 35 points
        for (int x = 0; x < item.Sales.Length; x++)
        {
            chart.Series[0].Points.AddXY(x, item.Sales[x]);
        }
    
         // Start hiding both sets of axes, labels, gridlines and tick marks
         chart.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
         chart.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
         chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
         chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
         chart.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
         chart.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
         chart.ChartAreas[0].AxisX.LineWidth = 0;
         chart.ChartAreas[0].AxisY.LineWidth = 0;
    
         // Sparklines use the 'Spline' chart type to show a smoother trend with a line chart
         chart.Series[0].ChartType = SeriesChartType.Spline;
    
         // Since the line is the only thing you see on the chart, you might want to
         // increase its width.&nbsp; Interestingly, you need to set the BorderWidth property
         // in order to accomplish that.
         chart.Series[0].BorderWidth = 2;
    
         // Re-adjust the size of the chart to reduce unnecessary white space
         chart.Width = 400;
         chart.Height = 100;
         string base64;
         using (MemoryStream ms = new MemoryStream())
         {
             chart.SaveImage(ms);
             var bytes = ms.GetBuffer();
             base64 = Convert.ToBase64String(bytes);
         }
     /**
      * Here's a simpler example that would do a regular chart, 
      * rather than a sparkline. No way to make the gridlines and axes go
      * away with this helper that I'm aware of.
      
        var chart = new Chart(
            width: 300,
            height: 100
            )
            .AddSeries(chartType: "Spline", yValues: item.Sales);
        var bytes = chart.GetBytes();
        var base64 = Convert.ToBase64String(bytes);    
                 */
                    }
                 <img src="data:image/jpeg;base64,@base64" />
            </td>
        </tr>
    }
    
    </table>
