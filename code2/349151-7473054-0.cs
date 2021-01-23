    public void Save(Street street)
    {
        string postalCode = street.PostalCode;
        string streetCode = steet.StreetCode;
        bool existingStreet = streetContext.Streets.Any(s =>
                                s.PostalCode == postalCode
                                && s.StreetCode = steetCode);
        if (existingStreet)
            streetContext.Entry(street).State = System.Data.EntityState.Modified;
        else
            streetContext.Entry(street).State = System.Data.EntityState.Added;
        streetContext.SaveChanges();
    }
