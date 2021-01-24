C#
public static IEnumerable<TSalesData> SalesTotalsCompute<TSalesData>(System.Data.IDbConnection connection)
    where TSalesData : ISalesMetric
{
    string joinedGroupByColumnsNames = string.Join(",", GetNonSalesMetricColumnNamesFor<TSalesData>());
    return connection.Query<TSalesData>(sql: $@"
        SELECT SUM(SalesDollars) AS SalesDollars,
            SUM(SalesUnits) AS SalesUnits,
            {joinedGroupByColumnsNames}
        FROM dbo.FlatSales
        GROUP BY {joinedGroupByColumnsNames}
    ");
}
Also, I'd recommend to move the reflection part outside of this method and only run it once for every type that you're using (so keep a cache in a static concurrent dictionary, using the model type as key and column names as value). You obviously want to exclude the properties from the `ISalesMetric` interface.
