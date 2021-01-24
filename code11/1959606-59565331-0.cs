public static class CoordinateExtensions {
	public static Coordinate ProjectTo(
		this Coordinate coordinate,
		int fromSrid,
		int toSrid) {
		var point = new Point(coordinate) {
			SRID = fromSrid
		};
		return point.ProjectTo(toSrid).Coordinate;
	}
}
public static class GeometryExtensions {
	private static readonly CoordinateSystemServices Services = new CoordinateSystemServices(new Dictionary<int, string> {
		{ 4326, GeographicCoordinateSystem.WGS84.WKT },
		{ 2855, @"
			PROJCS[""NAD83(HARN) / Washington North"",
			    GEOGCS[""NAD83(HARN)"",
					DATUM[""NAD83_High_Accuracy_Reference_Network"",
						SPHEROID[""GRS 1980"",6378137,298.257222101,
							AUTHORITY[""EPSG"",""7019""]],
			            TOWGS84[0, 0, 0, 0, 0, 0, 0],
			            AUTHORITY[""EPSG"", ""6152""]],
			        PRIMEM[""Greenwich"", 0,
						AUTHORITY[""EPSG"", ""8901""]],
			        UNIT[""degree"", 0.0174532925199433,
						AUTHORITY[""EPSG"", ""9122""]],
			        AUTHORITY[""EPSG"", ""4152""]],
			    PROJECTION[""Lambert_Conformal_Conic_2SP""],
			    PARAMETER[""standard_parallel_1"", 48.73333333333333],
			    PARAMETER[""standard_parallel_2"", 47.5],
			    PARAMETER[""latitude_of_origin"", 47],
			    PARAMETER[""central_meridian"", -120.8333333333333],
			    PARAMETER[""false_easting"", 500000],
			    PARAMETER[""false_northing"", 0],
			    UNIT[""metre"", 1,
					AUTHORITY[""EPSG"", ""9001""]],
			    AXIS[""X"", EAST],
			    AXIS[""Y"", NORTH],
			    AUTHORITY[""EPSG"", ""2855""]]
		" }
	});
	public static Geometry ProjectTo(
		this Geometry geometry,
		int toSrid) {
		if (geometry.Coordinates.Length == 1) {
			return geometry.ProjectToSingle(toSrid);
		}
		return geometry.ProjectToMany(toSrid);
	}
	private static Geometry ProjectToSingle(
		this Geometry geometry,
		int toSrid) {
		var transformation = Services.CreateTransformation(geometry.SRID, toSrid);
		var transformer = new MathTransformFilter(transformation.MathTransform);
		var transformed = geometry.Copy();
		transformed.Apply(transformer);
		transformed.SRID = toSrid;
		return transformed;
	}
	private static Geometry ProjectToMany(
		this Geometry geometry,
		int toSrid) {
		var fromSrid = geometry.SRID;
		var transformed = geometry.Copy();
		for (var i = 0; i < transformed.Coordinates.Length; i++) {
			var coordinate = transformed.Coordinates[i].ProjectTo(fromSrid, toSrid);
			transformed.Coordinates[i].CoordinateValue = coordinate.CoordinateValue;
		}
		transformed.SRID = toSrid;
		return transformed;
	}
}
public sealed class MathTransformFilter :
	ICoordinateSequenceFilter {
	private readonly MathTransform Transform;
	public MathTransformFilter(
		MathTransform transform) => Transform = transform;
	public bool Done => false;
	public bool GeometryChanged => true;
	public void Filter(
		CoordinateSequence seq,
		int i) {
		var result = Transform.Transform(new[] {
			seq.GetOrdinate(i, Ordinate.X),
			seq.GetOrdinate(i, Ordinate.Y)
		});
		seq.SetOrdinate(i, Ordinate.X, result[0]);
		seq.SetOrdinate(i, Ordinate.Y, result[1]);
	}
}
  [1]: https://www.spatialreference.org/
  [2]: https://epsg.io/
