    var queryable = qLogs.FromSql("select * from \"" + tableName + "\" order by \"" + orderField + "\"");
    var result = qCars.Select(x => new RouteModel
    {
       Mileage = Math.Round(
           collection
               .Where(y => y.CarId == x.Id)
               .Select(y => PostgisExtensions.ST_LengthSpheroid(
                        PostgisExtensions.ST_MakeLine(
                            PostgisExtensions.ST_GeomFromText(y.Location.AsText(),          PostgisConstants.MetricSrid)
                        ),
                       PostgisConstants.SpheroidWgs84)
               )
               .FirstOrDefault() / 1000),
     .....
