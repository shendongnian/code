    var wkt = "POLYGON ((10 20, 30 40, 50 60, 10 20))";
    var wktReader = new NetTopologySuite.IO.WKTReader();
    var geom = wktReader.Read(wkt);
    var feature = new NetTopologySuite.Features.Feature(geom, new NetTopologySuite.Features.AttributesTable());
    var featureCollection = new NetTopologySuite.Features.FeatureCollection();
    featureCollection.Add(feature);
    var sb = new StringBuilder();
    var serializer = new NetTopologySuite.IO.GeoJsonSerializer();
    serializer.Formatting = Newtonsoft.Json.Formatting.Indented;
    using (var sw = new StringWriter(sb))
    {
        serializer.Serialize(sw, featureCollection);
    }
    var result = sb.ToString();
