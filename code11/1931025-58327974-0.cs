public class GeopointProxy : IGeoshape {
    public GeopointProxy() { }
    private AltitudeReferenceSystem _altitudeReferenceSystem;
    // This is part of the IGeoshape interface, you can't change it's signature, and it's readonly.  Fun.
    [JsonIgnore]
    public AltitudeReferenceSystem AltitudeReferenceSystem { get { return _altitudeReferenceSystem; } }  
    public AltitudeReferenceSystem SettableAltitudeReferenceSystem {
        get {
            return AltitudeReferenceSystem;
        }
        set {
            _altitudeReferenceSystem = value;
        }
    }
    // rinse and repeat as appropriate for the other interface members and class properties
    // Then include a conversion function, or get fancy and add type conversion operators:
    public Geopoint ToGeopoint() {
        return new Geopoint(Position, AltitudeReferenceSystem, SpatialReferenceId);
    }
}
