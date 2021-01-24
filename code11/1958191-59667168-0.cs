    var x = 13.003725d;
    var y = 55.604870d;
	
    var epsg3857ProjectedCoordinateSystem = ProjNet.CoordinateSystems.ProjectedCoordinateSystem.WebMercator;
    var epsg4326GeographicCoordinateSystem = ProjNet.CoordinateSystems.GeographicCoordinateSystem.WGS84;
    var coordinateTransformationFactory = new ProjNet.CoordinateSystems.Transformations.CoordinateTransformationFactory();
    var coordinateTransformation = coordinateTransformationFactory.CreateFromCoordinateSystems(epsg4326GeographicCoordinateSystem, epsg3857ProjectedCoordinateSystem);
    var epsg4326Coordinate = new GeoAPI.Geometries.Coordinate(x, y);
    var epsg3857Coordinate = coordinateTransformation.MathTransform.Transform(epsg4326Coordinate);
