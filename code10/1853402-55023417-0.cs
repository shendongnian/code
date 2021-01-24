    var csWgs84 = ProjNet.CoordinateSystems.GeographicCoordinateSystems.WGS84;
    const string epsg27700 = "..."; // see http://epsg.io/27700
    var cs27700 = ProjNet.Converters.WellKnownText.CoordinateSystemWktReader.Parse(epsg27700);
    var ctFactory = new ProjNet.CoordinateSystems.Transformations.CoordinateTransformationFactory();
    var ct = ctFactory.CreateFromCoordinateSystems(csWgs84, cs27700);
    var mt = ct.MathTransform;
    
    var gf = new NetTopologySuite.Geometries.GeometryFactory(27700);
    // BT2 8HB
    var myPostcode = gf.CreatePoint(mt.Transform(new Coordinate(-5.926223, 54.592395)));
    // DT11 0DB
    var myMatesPostcode = gf.CreatePoint(mt.Transform(new Coordinate(-2.314507, 50.827157)));
    
    double distance = myPostcode.Distance(myMatesPostcode);
