    string json = // Your JSON string
    Listing myListing = DeserializeJSON(json);
    foreach (Quote quote in listing.Quotes)
    {
        DateTime dt = quote.Date;
        Double lastAdjusted = quote.LastAdjusted;
    }
    public Listing DeserializeJSON(string json)
    {
        using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Listing));
            return (Listing)serializer.ReadObject(ms);
        }
    }
