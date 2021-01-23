    [SuppressMessage("Microsoft.Contracts", "Requires",
                     Justification = "Bug in static checker")]
    public void Override(AutoMapping<Bookings> mapping)
    {
        Contract.Assume(mapping != null);
        mapping.Id(x => x.Id);
    }
