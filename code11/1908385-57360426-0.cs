<button command="{binding AddChart}" />
<ListBox ItemsSource="{Binding ChartDataSets}" IsSynchronizedWithCurrentItem="true">
        <ListBox.ItemTemplate>
            <DataTemplate>
                    <views:OxyPlotChart MinWidth="600" MinHeight="300" />
            </DataTemplate>
        </ListBox.ItemTemplate>
</ListBox>
OxyPLotChart.xaml
<oxy:PlotView Model="{Binding}" />
in OxyPlotModel (*assuming your code is correct)
public IObservableCollection<PlotView> ChartDataSets;
public DelegateCommand AddChart { get; private set;}
public OxyPlotModel()
{
    ChartDataSets = new ObservableCollection<PlotView>();
    AddChart = new DelegateCommand(AddOxyChart);
}
private void AddOxyChart()
{
     var plotView = new PlotView();
     plotView.Height = 300;
     plotView.Width = 600;
     plotView.VerticalAlignment = System.Windows.VerticalAlignment.Top;
     var oxyPlotModel = new OxyPlotModel();
     var plotModel = new PlotModel();
     plotView.DataContext = oxyPlotModel;
     oxyPlotModel.PlotModel = plotModel;
     SetUpAxes(ref plotModel);
     plotModel.Axes[1].IsZoomEnabled = true;
     ChartDataSets.Add(plotView);
}
private void SetUpAxes(ref PlotModel plotModel)
{
    plotModel.Axes.Clear();
    foreach (var axis in plotModel.Axes)
        axis.Reset();
    var yAxis = new OxyPlot.Axes.LinearAxis();
    var xAxis = new OxyPlot.Axes.DateTimeAxis();
    yAxis.IsZoomEnabled = false;
    yAxis.AbsoluteMinimum = -50;
    yAxis.AbsoluteMaximum = 450;
    yAxis.MajorGridlineStyle = LineStyle.Solid;
    xAxis.MajorGridlineStyle = LineStyle.Solid;
    xAxis.AbsoluteMinimum = OxyPlot.Axes.DateTimeAxis.ToDouble(new DateTime (Convert.ToDateTime("21/01/14 " + "00:00:00").Ticks));
     xAxis.AbsoluteMaximum = OxyPlot.Axes.DateTimeAxis.ToDouble(new DateTime(Convert.ToDateTime("21/01/14 " + "00:00:00").AddDays(1).Ticks));
    yAxis.IsPanEnabled = false;
    yAxis.IsZoomEnabled = false;
    yAxis.Font = "Open Sans";
    xAxis.Font = "Open Sans";
    plotModel.Axes.Add(yAxis);
    plotModel.Axes.Add(xAxis);
}
