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
**Remarks**
 - I've reordered the columns, because splitOn needs the name of the column where the two objects split up, otherwise you'd have to pass the first item from the `joinedGroupByColumnsNames`-array which is a bit more random
 - If you're on .NET Standard, consider returning [`ValueTuple`](https://docs.microsoft.com/en-us/dotnet/api/system.valuetuple?view=netcore-3.0)'s instead of `KeyValuePair`'s
 - Don't use reflection for every call, I suggest to add a method `GetCachedColumnNamesFor` that does the reflection only once, using a static ConcurrentDictionary, calling the [`ConcurrentDictionary.GetOrAdd`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentdictionary-2.getoradd?view=netcore-3.0) method.
**Other approach**
You could also let `ProductGroup` inherit from `SalesMetrics` (or make an `ISalesMetrics` interface and let `ProductGroup` implement that interface) and do `Query<ProductGroup>(...)`. An additional benefit would be that duplicate fields in both models would be blocked by the compiler.
The resulting method would then look like this:
C#
public static IEnumerable<TSalesData> SalesTotalsCompute<TSalesData>(System.Data.IDbConnection connection)
    where TSalesData : ISalesMetric
{
    string joinedGroupByColumnsNames = string.Join(",", GetCachedNonSalesMetricColumnNamesFor<TSalesData>());
    return connection.Query<TSalesData>(sql: $@"
        SELECT SUM(SalesDollars) AS SalesDollars,
            SUM(SalesUnits) AS SalesUnits,
            {joinedGroupByColumnsNames}
        FROM dbo.FlatSales
        GROUP BY {joinedGroupByColumnsNames}
    ");
}
Here the `GetCachedNonSalesMetricColumnNamesFor`-method reflects the properties from `TSalesData` excluding those from the `ISalesMetric` interface, again, caching the result.
