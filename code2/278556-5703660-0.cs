    public override int GetHashCode()
    {
        var hash = 17;
        hash = hash*23 + Math.Round(Real, 5).GetHashCode();
        hash = hash*23 + Math.Round(Imaginary, 5).GetHashCode();
        return hash;
    }
