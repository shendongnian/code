csharp
List<MyClass> aLotOfCharts = new List<MyClass>()
SeriesCollection = new SeriesCollection()
for(int i=0; i < aLotOfCharts.Count; i++)
{
    SeriesCollection.Add(new LineSeries
            {
                Values = new ChartValues<double> (aLotOfCharts[i].a)
            });
}
