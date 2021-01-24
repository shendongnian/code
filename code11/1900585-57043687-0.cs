C#
private static double CalculateRealizedCorrelation(ObjectSeries<string> objectSeries)
{
    var openSeries = objectSeries.GetAs<Series<DateTime, double>>("Open");
    var closeSeries = objectSeries.GetAs<Series<DateTime, double>>("Close");
    return MathNet.Numerics.Statistics.Correlation.Pearson(openSeries.Values, closeSeries.Values);
}
var rollingAgg = new Dictionary<string, Series<DateTime, Series<DateTime, double>>>();
foreach (var column in msft.ColumnKeys)
{
    rollingAgg[column] = msft.GetColumn<double>(column);
}
var rollingDf = Frame.FromColumns(rollingAgg);
var rolingCorr = rollingDf.Rows.Select(kvp => CalculateRealizedCorrelation(kvp.Value));
