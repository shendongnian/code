    class Country : IComparable<Country>
    {
        int IComparable<Country>.CompareTo(Country other)
        {
            <US logic>
            else
                return String.Compare(this.CountryName, other.CountryName);
        }
    }
