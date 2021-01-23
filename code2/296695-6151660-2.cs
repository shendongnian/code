    public override bool Equals(Object other)
    {
        return other is GeoCoordinate && Equals((GeoCoordinate) other);
    }
    public bool Equals(GeoCoordinate other)
    {
        return Latitude == other.Latitude && Longitude == other.Longitude;
    }
    public override int GetHashCode()
    {
        return Latitude.GetHashcode() ^ Longitude.GetHashCode();
    }
