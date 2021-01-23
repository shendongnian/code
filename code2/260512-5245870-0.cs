    using System.Windows.Forms;
    using System.Windows.Forms.DataVisualization.Charting;
    
    // Collection of elements with 'Label' and 'Value' properties
    var data = (...)
    
    // Create a chart containing a default area and show it on a form
    var chart = new Chart { Dock = DockStyle.Fill };
    var form = new Form { Visible = true, Width = 700, Height = 500 };
    chart.ChartAreas.Add(new ChartArea("MainArea"));
    form.Controls.Add(chart);
    
    // Create series and add it to the chart
    var series = new Series { ChartType = SeriesChartType.Pie };
    chart.Series.Add(series);
    // Specify data for the series using data-binding
    series.Points.DataBindXY(data, "Label", data, "Value");
