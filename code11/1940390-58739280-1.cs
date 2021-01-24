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
If you want to continue with the `KeyValuePair<>` solution, perhaps you can benefit from Dapper's [multi-mapping feature](https://dapper-tutorial.net/result-multi-mapping):
C#
public static IEnumerable<KeyValuePair<TGroup, SalesMetrics>> SalesTotalsCompute<TGroup>(System.Data.IDbConnection connection)
{
    string joinedGroupByColumnsNames = string.Join(",", GetCachedColumnNamesFor<TGroup>());
    return connection.Query<TGroup, SalesMetrics, KeyValuePair<TGroup, SalesMetrics>>(
        sql: $@"SELECT {joinedGroupByColumnsNames},
                       SUM(SalesDollars) AS SalesDollars,
                       SUM(SalesUnits) AS SalesUnits
                  FROM dbo.FlatSales
              GROUP BY {joinedGroupByColumnsNames}",
        map: (groupData, salesMetricData) => new KeyValuePair<TGroup, SalesMetric>(groupData, salesMetricData),
        splitOn: "SalesDollars");
}
Note 1: I've reordered the columns, because splitOn needs the name of the column where the two objects split up, otherwise you'd have to pass the first item from the `joinedGroupByColumnsNames`-array which is a bit more random :)
Note 2: If you're on .NET Standard, consider returning a tuple instead of a KeyValuePair.
