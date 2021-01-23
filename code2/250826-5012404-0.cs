    public string EncodedAddress
    {
        get
        {
            if (Listing == null)
                return string.Empty;
            if (Listing.Address == null)
                return string.Empty;
            return encode(Listing.Address.Line1);
        }
    }
